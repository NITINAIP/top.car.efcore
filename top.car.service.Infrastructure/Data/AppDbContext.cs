using Microsoft.EntityFrameworkCore;
using top.car.service.Domain.Entities;

namespace top.car.service.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<BzMasterGl> BzMasterGls => Set<BzMasterGl>();
    public DbSet<BzMasterIo> BzMasterIos => Set<BzMasterIo>();
    public DbSet<BzUsers> BzUsers => Set<BzUsers>();
    public DbSet<CarsApprover> CarsApprovers => Set<CarsApprover>();
    public DbSet<CarsApproverDetail> CarsApproverDetails => Set<CarsApproverDetail>();
    public DbSet<CarsAuthorization> CarsAuthorizations => Set<CarsAuthorization>();
    public DbSet<CarsCalendarEvent> CarsCalendarEvents => Set<CarsCalendarEvent>();
    public DbSet<CarsDetailBooking> CarsDetailBookings => Set<CarsDetailBooking>();
    public DbSet<CarsDetailReq> CarsDetailReqs => Set<CarsDetailReq>();
    public DbSet<CarsDetailTraveler> CarsDetailTravelers => Set<CarsDetailTraveler>();
    public DbSet<CarsFeedback> CarsFeedbacks => Set<CarsFeedback>();
    public DbSet<CarsLoginLog> CarsLoginLogs => Set<CarsLoginLog>();
    public DbSet<CarsMtCarcomp> CarsMtCarcomps => Set<CarsMtCarcomp>();
    public DbSet<CarsMtCarfrom> CarsMtCarfroms => Set<CarsMtCarfrom>();
    public DbSet<CarsMtCartype> CarsMtCartypes => Set<CarsMtCartype>();
    public DbSet<CarsMtComp> CarsMtComps => Set<CarsMtComp>();
    public DbSet<CarsMtDriver> CarsMtDrivers => Set<CarsMtDriver>();
    public DbSet<CarsMtService> CarsMtServices => Set<CarsMtService>();
    public DbSet<CarsMtStatus> CarsMtStatuses => Set<CarsMtStatus>();
    public DbSet<CarsMtStep> CarsMtSteps => Set<CarsMtStep>();
    public DbSet<CarsRoute> CarsRoutes => Set<CarsRoute>();
    public DbSet<CarsUserProfile> CarsUserProfiles => Set<CarsUserProfile>();
    public DbSet<CarsWfProcess> CarsWfProcesses => Set<CarsWfProcess>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
