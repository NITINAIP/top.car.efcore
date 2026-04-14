using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Commons;
using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class BzMasterIoRepo(AppDbContext context) : Repository<BzMasterIo>(context), IBzMasterIoRepo
{
    public async Task<Selection[]> GetSelectionAsync(CancellationToken cancellationToken = default)
    {
        return await context.BzMasterIos
            .AsNoTracking()
            .Select(c => new Selection { Id = $"{c.IoCate}", Value = $"{c.IoCate}" })
            .ToArrayAsync(cancellationToken);
    }
}
