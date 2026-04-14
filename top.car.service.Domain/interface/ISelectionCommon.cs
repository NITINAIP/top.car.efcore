using top.car.service.Domain.Commons;

namespace top.car.service.Domain.Interface;

public interface ISelectionCommon {
    Task<Selection[]> GetSelectionAsync(CancellationToken cancellationToken = default);
}
