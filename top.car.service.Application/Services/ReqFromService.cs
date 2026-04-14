using AutoMapper;
using top.car.service.Application.DTOs.ReqForm;
using top.car.service.Application.Interface;
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
                DocumentNo = doc.Item1,
            };
        }
        return _mapper.Map<ReqFormDto>(result);
    }
}

