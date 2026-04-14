using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Commons;
using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsMtCarcompRepo(AppDbContext context) : Repository<CarsMtCarcomp>(context), ICarsMtCarcompRepo
{
    public async Task<Selection[]> GetSelectionAsync(CancellationToken cancellationToken = default)
    {
        return await context.CarsMtCarcomps
            .AsNoTracking()
            .Select(c => new Selection { Id = $"{c.Id}", Value = $"{c.CarsFrom}" })
            .ToArrayAsync(cancellationToken);
    }
}