using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsMtStepRepo(AppDbContext context) : Repository<CarsMtStep>(context), ICarsMtStepRepo
{

}
