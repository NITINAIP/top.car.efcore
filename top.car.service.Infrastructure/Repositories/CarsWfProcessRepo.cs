using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsWfProcessRepo(AppDbContext context) : Repository<CarsWfProcess>(context), ICarsWfProcessRepo
{
    /// <summary>
    /// Generates a new document number in the format "CS00-YYMM-XXXX" where:
    /// - "CS00" is a fixed prefix.
    /// - "YYMM" is the current year and month.
    /// - "XXXX" is a zero-padded running number that increments with each new document created within the same month.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<(string,int,int,int)> NewDocumentNoAsync(CancellationToken cancellationToken = default)
    {
        // Generate new document number in the format "CS00-YYMM-XXXX"
        var maxRunningNo = await context.CarsWfProcesses
        .MaxAsync(p => (int?)p.RunningNo, cancellationToken) ?? 0;
        var newRunningNo = maxRunningNo + 1;
        return ($"CS00-{DateTimeOffset.UtcNow:yyMM}-{newRunningNo.ToString("0000")}", DateTimeOffset.UtcNow.Year, DateTimeOffset.UtcNow.Month, newRunningNo);
    }
}
