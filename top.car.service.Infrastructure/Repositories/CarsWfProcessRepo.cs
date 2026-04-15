using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;
using Top.Car.Service.Domain.ValueObject;

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
    public async Task<Document> NewDocumentNoAsync(CancellationToken cancellationToken = default)
    {
        // Generate new document number in the format "CS00-YYMM-XXXX"
        var maxRunningNo = await context.CarsWfProcesses
        .MaxAsync(p => (int?)p.RunningNo, cancellationToken) ?? 0;
        var maxId = await context.CarsWfProcesses
        .MaxAsync(p => (int?)p.Id, cancellationToken) ?? 0;
        var newRunningNo = maxRunningNo + 1;
        var documentWf = new DocumentWf($"CS00-{DateTimeOffset.UtcNow:yyMM}-{newRunningNo:0000}", maxId, DateTimeOffset.UtcNow.Year, DateTimeOffset.UtcNow.Month, newRunningNo);
        return new Document(documentWf);
    }

    public async Task<Document> NewDocumentNoByCarTypeAsync(int CarType, CancellationToken cancellationToken = default)
    {
        // Generate new document number in the format "CS{CarType}-YYMM-XXXX"
        var maxRunningNo = await context.CarsWfProcesses
        .MaxAsync(p => (int?)p.RunningNo, cancellationToken) ?? 0;
        var maxId = await context.CarsWfProcesses
        .MaxAsync(p => (int?)p.Id, cancellationToken) ?? 0;
        var newRunningNo = maxRunningNo + 1;
        var documentWf = new DocumentWf($"CS{CarType:00}-{DateTimeOffset.UtcNow:yyMM}-{newRunningNo:0000}", maxId, DateTimeOffset.UtcNow.Year, DateTimeOffset.UtcNow.Month, newRunningNo);
        return new Document(documentWf);
    }
}
