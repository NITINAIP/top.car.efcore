using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsCalendarEventRepo : IRepositoryRead<CarsCalendarEvent>, IRepositoryWrite<CarsCalendarEvent> { }
