using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsMtCarfromRepo(AppDbContext context) : Repository<CarsMtCarfrom>(context), ICarsMtCarfromRepo
{

}
