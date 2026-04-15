using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;
using Top.Car.Service.Domain.ValueObject;

public interface ICarsWfProcessRepo : IRepositoryRead<CarsWfProcess>, IRepositoryWrite<CarsWfProcess>
{

    public Task<Document> NewDocumentNoAsync(CancellationToken cancellationToken = default);
    public Task<Document> NewDocumentNoByCarTypeAsync(int CarType,CancellationToken cancellationToken = default);
}
