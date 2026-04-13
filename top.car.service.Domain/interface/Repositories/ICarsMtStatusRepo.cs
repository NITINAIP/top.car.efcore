using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsMtStatusRepo : IRepositoryRead<CarsMtStatus>, IRepositoryWrite<CarsMtStatus> { }
