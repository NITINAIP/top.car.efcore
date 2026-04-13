using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsRouteRepo : IRepositoryRead<CarsRoute>, IRepositoryWrite<CarsRoute> { }
