using top.car.service.Application.DTOs.ReqForm;

namespace top.car.service.Application.Interface;
public interface IReqFromService
{
    Task<ReqFormDto> GetReqFromAsync(int Id, CancellationToken cancellationToken = default);
    Task<int> SaveReqFromAsync(UpSertReqFormDto model, CancellationToken cancellationToken = default);
}