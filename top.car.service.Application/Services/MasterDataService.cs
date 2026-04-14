using top.car.service.Application.Interface;
using top.car.service.Domain.Commons;
using top.car.service.Domain.Interface.Repositories;

namespace top.car.service.Application.Services;
public class MasterDataService(ICarServiceRepositoryManager manager) : IMasterDataService
{
    private readonly ICarServiceRepositoryManager _manager = manager;

    public Task<Selection[]> GetCompaniesAsync(CancellationToken cancellationToken = default)
        => _manager.CarsMtCompRepo.GetSelectionAsync(cancellationToken);

    public Task<Selection[]> GetDriversAsync(CancellationToken cancellationToken = default)
        => _manager.CarsMtDriverRepo.GetSelectionAsync(cancellationToken);

    public Task<Selection[]> GetServicesAsync(CancellationToken cancellationToken = default)
        => _manager.CarsMtServiceRepo.GetSelectionAsync(cancellationToken);

    public Task<Selection[]> GetStatusesAsync(CancellationToken cancellationToken = default)
        => _manager.CarsMtStatusRepo.GetSelectionAsync(cancellationToken);

    public Task<Selection[]> GetStepsAsync(CancellationToken cancellationToken = default)
        => _manager.CarsMtStepRepo.GetSelectionAsync(cancellationToken);

    public Task<Selection[]> GetCarFromsAsync(CancellationToken cancellationToken = default)
        => _manager.CarsMtCarfromRepo.GetSelectionAsync(cancellationToken);

    public Task<Selection[]> GetCarTypesAsync(CancellationToken cancellationToken = default)
        => _manager.CarsMtCartypeRepo.GetSelectionAsync(cancellationToken);

    public Task<Selection[]> GetCarCompsAsync(CancellationToken cancellationToken = default)
        => _manager.CarsMtCarcompRepo.GetSelectionAsync(cancellationToken);

    public Task<Selection[]> GetIoCategoriesAsync(CancellationToken cancellationToken = default)
        => _manager.BzMasterIoRepo.GetSelectionAsync(cancellationToken);
}