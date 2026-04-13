using top.car.service.Domain.Interface.Repositories;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

namespace top.car.service.Infrastructure.Repositories;

public class CarServiceRepositoryManager(AppDbContext context) : RepositoryManager(context), ICarServiceRepositoryManager
{
    private readonly AppDbContext _context = context;

    public IBzMasterGlRepo BzMasterGlRepo => new BzMasterGlRepo(_context);
    public IBzMasterIoRepo BzMasterIoRepo => new BzMasterIoRepo(_context);
    public IBzUsersRepo BzUsersRepo => new BzUsersRepo(_context);
    public ICarsApproverRepo CarsApproverRepo => new CarsApproverRepo(_context);
    public ICarsApproverDetailRepo CarsApproverDetailRepo => new CarsApproverDetailRepo(_context);
    public ICarsAuthorizationRepo CarsAuthorizationRepo => new CarsAuthorizationRepo(_context);
    public ICarsCalendarEventRepo CarsCalendarEventRepo => new CarsCalendarEventRepo(_context);
    public ICarsDetailBookingRepo CarsDetailBookingRepo => new CarsDetailBookingRepo(_context);
    public ICarsDetailReqRepo CarsDetailReqRepo => new CarsDetailReqRepo(_context);
    public ICarsDetailTravelerRepo CarsDetailTravelerRepo => new CarsDetailTravelerRepo(_context);
    public ICarsFeedbackRepo CarsFeedbackRepo => new CarsFeedbackRepo(_context);
    public ICarsLoginLogRepo CarsLoginLogRepo => new CarsLoginLogRepo(_context);
    public ICarsMtCarcompRepo CarsMtCarcompRepo => new CarsMtCarcompRepo(_context);
    public ICarsMtCarfromRepo CarsMtCarfromRepo => new CarsMtCarfromRepo(_context);
    public ICarsMtCartypeRepo CarsMtCartypeRepo => new CarsMtCartypeRepo(_context);
    public ICarsMtCompRepo CarsMtCompRepo => new CarsMtCompRepo(_context);
    public ICarsMtDriverRepo CarsMtDriverRepo => new CarsMtDriverRepo(_context);
    public ICarsMtServiceRepo CarsMtServiceRepo => new CarsMtServiceRepo(_context);
    public ICarsMtStatusRepo CarsMtStatusRepo => new CarsMtStatusRepo(_context);
    public ICarsMtStepRepo CarsMtStepRepo => new CarsMtStepRepo(_context);
    public ICarsRouteRepo CarsRouteRepo => new CarsRouteRepo(_context);
    public ICarsUserProfileRepo CarsUserProfileRepo => new CarsUserProfileRepo(_context);
    public ICarsWfProcessRepo CarsWfProcessRepo => new CarsWfProcessRepo(_context);
}
