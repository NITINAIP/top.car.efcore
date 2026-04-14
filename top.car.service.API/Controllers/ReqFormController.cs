using Microsoft.AspNetCore.Mvc;
using top.car.service.API.Result;
using top.car.service.Application.Interface;

[ApiController]
[Route("api/[controller]")]
public class ReqFormController(IReqFromService service) : ControllerBase
{
    readonly IReqFromService _service = service;
    [HttpGet("get-req-form")]
    public async Task<IActionResult> GetReqFromAsync([FromQuery(Name = "id")] int Id, CancellationToken cancellationToken = default)
    {
        var result = await _service.GetReqFromAsync(Id, cancellationToken);
        return Result.Ok(result, "GetReqFromAsync Success");
    }
}