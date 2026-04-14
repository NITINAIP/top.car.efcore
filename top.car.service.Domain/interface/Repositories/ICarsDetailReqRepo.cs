using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsDetailReqRepo : IRepositoryRead<CarsDetailReq>, IRepositoryWrite<CarsDetailReq> {

    Task<CarsDetailReq?> GetReqDetailWithBookingAndTravelerAsync(int id, CancellationToken cancellationToken = default);
 }
