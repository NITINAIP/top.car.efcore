using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsFeedbackRepo : IRepositoryRead<CarsFeedback>, IRepositoryWrite<CarsFeedback> { }
