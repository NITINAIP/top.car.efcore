using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsMtServiceRepo : IRepositoryRead<CarsMtService>, IRepositoryWrite<CarsMtService> { }
