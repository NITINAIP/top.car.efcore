using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsApproverRepo(AppDbContext context) : Repository<CarsApprover>(context), ICarsApproverRepo
{

}
