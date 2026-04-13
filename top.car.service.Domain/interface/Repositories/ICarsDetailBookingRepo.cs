using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsDetailBookingRepo : IRepositoryRead<CarsDetailBooking>, IRepositoryWrite<CarsDetailBooking> { }
