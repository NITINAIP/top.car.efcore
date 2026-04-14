using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsMtDriverRepo : IRepositoryRead<CarsMtDriver>, IRepositoryWrite<CarsMtDriver>, ISelectionCommon { }
