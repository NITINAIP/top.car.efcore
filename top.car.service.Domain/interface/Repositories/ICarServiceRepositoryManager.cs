namespace top.car.service.Domain.Interface.Repositories;
public interface ICarServiceRepositoryManager : IRepository
{
    IBzMasterGlRepo BzMasterGlRepo { get; }
    IBzMasterIoRepo BzMasterIoRepo { get; }
    IBzUsersRepo BzUsersRepo { get; }
    ICarsApproverRepo CarsApproverRepo { get; }
    ICarsApproverDetailRepo CarsApproverDetailRepo { get; }
    ICarsAuthorizationRepo CarsAuthorizationRepo { get; }
    ICarsCalendarEventRepo CarsCalendarEventRepo { get; }
    ICarsDetailBookingRepo CarsDetailBookingRepo { get; }
    ICarsDetailReqRepo CarsDetailReqRepo { get; }
    ICarsDetailTravelerRepo CarsDetailTravelerRepo { get; }
    ICarsFeedbackRepo CarsFeedbackRepo { get; }
    ICarsLoginLogRepo CarsLoginLogRepo { get; }
    ICarsMtCarcompRepo CarsMtCarcompRepo { get; }
    ICarsMtCarfromRepo CarsMtCarfromRepo { get; }
    ICarsMtCartypeRepo CarsMtCartypeRepo { get; }
    ICarsMtCompRepo CarsMtCompRepo { get; }
    ICarsMtDriverRepo CarsMtDriverRepo { get; }
    ICarsMtServiceRepo CarsMtServiceRepo { get; }
    ICarsMtStatusRepo CarsMtStatusRepo { get; }
    ICarsMtStepRepo CarsMtStepRepo { get; }
    ICarsRouteRepo CarsRouteRepo { get; }
    ICarsUserProfileRepo CarsUserProfileRepo { get; }
    ICarsWfProcessRepo CarsWfProcessRepo { get; }
}
