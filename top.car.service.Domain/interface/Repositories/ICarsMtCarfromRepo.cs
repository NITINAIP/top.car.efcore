using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsMtCarfromRepo : IRepositoryRead<CarsMtCarfrom>, IRepositoryWrite<CarsMtCarfrom>, ISelectionCommon { }
