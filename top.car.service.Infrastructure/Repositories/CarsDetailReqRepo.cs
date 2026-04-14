using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class CarsDetailReqRepo(AppDbContext context) : Repository<CarsDetailReq>(context), ICarsDetailReqRepo
{
    public async Task<CarsDetailReq?> GetReqDetailWithBookingAndTravelerAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.CarsDetailReqs
            .Where(r => r.Id == id)
            .Include(r => r.CarsDetailBookings)
                .ThenInclude(b => b.CarsDetailTravelers)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
