using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsLoginLogRepo : IRepositoryRead<CarsLoginLog>, IRepositoryWrite<CarsLoginLog> { }
