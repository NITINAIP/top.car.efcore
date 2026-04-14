using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface ICarsWfProcessRepo : IRepositoryRead<CarsWfProcess>, IRepositoryWrite<CarsWfProcess>
{

    public Task<(string, int, int, int)> NewDocumentNoAsync(CancellationToken cancellationToken = default);
}
