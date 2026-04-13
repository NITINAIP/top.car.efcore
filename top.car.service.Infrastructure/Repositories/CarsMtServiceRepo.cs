using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsMtServiceRepo(AppDbContext context) : Repository<CarsMtService>(context), ICarsMtServiceRepo
{

}
