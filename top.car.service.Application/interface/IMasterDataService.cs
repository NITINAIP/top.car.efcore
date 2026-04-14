using top.car.service.Domain.Commons;

namespace top.car.service.Application.Interface;

public interface IMasterDataService
{
    Task<Selection[]> GetCompaniesAsync(CancellationToken cancellationToken = default);
    Task<Selection[]> GetDriversAsync(CancellationToken cancellationToken = default);
    Task<Selection[]> GetServicesAsync(CancellationToken cancellationToken = default);
    Task<Selection[]> GetStatusesAsync(CancellationToken cancellationToken = default);
    Task<Selection[]> GetStepsAsync(CancellationToken cancellationToken = default);
    Task<Selection[]> GetCarFromsAsync(CancellationToken cancellationToken = default);
    Task<Selection[]> GetCarTypesAsync(CancellationToken cancellationToken = default);
    Task<Selection[]> GetCarCompsAsync(CancellationToken cancellationToken = default);
    Task<Selection[]> GetIoCategoriesAsync(CancellationToken cancellationToken = default);
}