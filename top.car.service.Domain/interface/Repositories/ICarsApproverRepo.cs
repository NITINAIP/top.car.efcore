using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsApproverRepo : IRepositoryRead<CarsApprover>, IRepositoryWrite<CarsApprover> { }
