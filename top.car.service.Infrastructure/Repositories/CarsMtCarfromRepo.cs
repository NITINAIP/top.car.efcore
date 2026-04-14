using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Commons;
using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsMtCarfromRepo(AppDbContext context) : Repository<CarsMtCarfrom>(context), ICarsMtCarfromRepo
{
    public async Task<Selection[]> GetSelectionAsync(CancellationToken cancellationToken = default)
    {
        return await context.CarsMtCarfroms
            .AsNoTracking()
            .Select(c => new Selection { Id = $"{c.Id}", Value = $"{c.Name}" })
            .ToArrayAsync(cancellationToken);
    }
}
