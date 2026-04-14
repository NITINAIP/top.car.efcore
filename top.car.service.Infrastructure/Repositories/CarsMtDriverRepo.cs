using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Commons;
using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsMtDriverRepo(AppDbContext context) : Repository<CarsMtDriver>(context), ICarsMtDriverRepo
{
    public async Task<Selection[]> GetSelectionAsync(CancellationToken cancellationToken = default)
    {
        return await context.CarsMtDrivers
            .AsNoTracking()
            .Select(c => new Selection { Id = $"{c.Id}", Value = $"{c.DriverName}" })
            .ToArrayAsync(cancellationToken);
    }
}
