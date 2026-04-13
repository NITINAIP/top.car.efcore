using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsCalendarEventRepo(AppDbContext context) : Repository<CarsCalendarEvent>(context), ICarsCalendarEventRepo
{

}
