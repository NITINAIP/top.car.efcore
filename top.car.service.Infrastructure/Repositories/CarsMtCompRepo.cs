using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Commons;
using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsMtCompRepo(AppDbContext context) : Repository<CarsMtComp>(context), ICarsMtCompRepo
{
    public async Task<Selection[]> GetSelectionAsync(CancellationToken cancellationToken = default)
    {
        return await context.CarsMtComps
            .AsNoTracking()
            .Select(c => new Selection { Id = $"{c.Id}", Value = $"{c.CompShortName}" })
            .ToArrayAsync(cancellationToken);
    }
}
