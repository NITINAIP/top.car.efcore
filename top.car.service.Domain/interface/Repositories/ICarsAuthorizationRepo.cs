using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsAuthorizationRepo : IRepositoryRead<CarsAuthorization>, IRepositoryWrite<CarsAuthorization> { }
