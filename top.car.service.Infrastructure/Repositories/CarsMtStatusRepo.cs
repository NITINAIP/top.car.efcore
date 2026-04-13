using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsMtStatusRepo(AppDbContext context) : Repository<CarsMtStatus>(context), ICarsMtStatusRepo
{

}
