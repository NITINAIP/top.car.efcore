using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Commons;
using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsMtStatusRepo(AppDbContext context) : Repository<CarsMtStatus>(context), ICarsMtStatusRepo
{
    public async Task<Selection[]> GetSelectionAsync(CancellationToken cancellationToken = default)
    {
        return await context.CarsMtStatuses
            .AsNoTracking()
            .Select(c => new Selection { Id = $"{c.Id}", Value = $"{c.Name}" })
            .ToArrayAsync(cancellationToken);
    }
}
