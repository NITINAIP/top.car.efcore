using AutoMapper;
using top.car.service.Application.DTOs.ReqForm;
using top.car.service.Application.Exceptions;
using top.car.service.Application.Interface;
using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

namespace top.car.service.Application.Services;
public class ReqFromService(ICarServiceRepositoryManager manager, IMapper mapper) : IReqFromService
{
    private readonly ICarServiceRepositoryManager _manager = manager;
    private readonly IMapper _mapper = mapper;

    public async Task<ReqFormDto> GetReqFromAsync(int Id, CancellationToken cancellationToken = default)
    {
        var result = await _manager.CarsDetailReqRepo.GetReqDetailWithBookingAndTravelerAsync(Id, cancellationToken);
        if (result == null)
        {
           var doc = await _manager.CarsWfProcessRepo.NewDocumentNoAsync(cancellationToken);
            return new ReqFormDto() {
                DocumentNo = doc.Value.DocumentNo,
            };
        }
        return _mapper.Map<ReqFormDto>(result);
    }

    public async Task<int> SaveReqFromAsync(UpSertReqFormDto model, CancellationToken cancellationToken = default)
    {
        if (model.Id > 0)
        {
            // ----- UPDATE: check existing, map scalar fields, delete-insert children -----
            var existing = await _manager.CarsDetailReqRepo.GetReqDetailWithBookingAndTravelerAsync(model.Id.Value, cancellationToken)
                ?? throw new NotFoundException($"CarsDetailReq id {model.Id} not found.");

            _mapper.Map(model, existing);

            // Delete-Insert: travelers first, then bookings
            foreach (var booking in existing.CarsDetailBookings.ToList())
            {
                foreach (var traveler in booking.CarsDetailTravelers.ToList())
                {
                    _manager.CarsDetailTravelerRepo.Delete(traveler);
                }
                _manager.CarsDetailBookingRepo.Delete(booking);
            }
            existing.CarsDetailBookings.Clear();

            foreach (var booking in BuildBookings(model.CarsDetails))
            {
                existing.CarsDetailBookings.Add(booking);
            }

            _manager.CarsDetailReqRepo.Update(existing);
            await _manager.SaveChangesAsync(cancellationToken);

            return existing.Id;
        }
        else
        {
            // ----- INSERT -----
            var entity = _mapper.Map<CarsDetailReq>(model);

            if (string.IsNullOrWhiteSpace(entity.DocNo))
            {
                var doc = await _manager.CarsWfProcessRepo.NewDocumentNoAsync(cancellationToken);
                entity.DocNo = doc.Value.DocumentNo;
            }

            foreach (var booking in BuildBookings(model.CarsDetails))
            {
                entity.CarsDetailBookings.Add(booking);
            }

            await _manager.CarsDetailReqRepo.AddAsync(entity, cancellationToken);
            await _manager.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }

    private IEnumerable<CarsDetailBooking> BuildBookings(List<CarsDetailReqDto> details)
    {
        var bookings = _mapper.Map<List<CarsDetailBooking>>(details);
        foreach (var booking in bookings)
        {
            var itemNo = booking.ItemNo ?? 0;
            foreach (var traveler in booking.CarsDetailTravelers)
            {
                traveler.BookingId = itemNo;
                traveler.ItemNoBooking ??= itemNo;
            }
        }
        return bookings;
    }
}

