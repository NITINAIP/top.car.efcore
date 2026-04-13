using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsRouteRepo(AppDbContext context) : Repository<CarsRoute>(context), ICarsRouteRepo
{

}
