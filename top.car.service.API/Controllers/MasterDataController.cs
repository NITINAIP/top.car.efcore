using Microsoft.AspNetCore.Mvc;
using top.car.service.API.Result;
using top.car.service.Application.Interface;

[ApiController]
[Route("api/master-data")]
public class MasterDataController(IMasterDataService service) : ControllerBase
{
    private readonly IMasterDataService _service = service;

    [HttpGet("companies")]
    public async Task<IActionResult> GetCompaniesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _service.GetCompaniesAsync(cancellationToken);
        return Result.Ok(result, "GetCompaniesAsync Success");
    }

    [HttpGet("drivers")]
    public async Task<IActionResult> GetDriversAsync(CancellationToken cancellationToken = default)
    {
        var result = await _service.GetDriversAsync(cancellationToken);
        return Result.Ok(result, "GetDriversAsync Success");
    }

    [HttpGet("services")]
    public async Task<IActionResult> GetServicesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _service.GetServicesAsync(cancellationToken);
        return Result.Ok(result, "GetServicesAsync Success");
    }

    [HttpGet("statuses")]
    public async Task<IActionResult> GetStatusesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _service.GetStatusesAsync(cancellationToken);
        return Result.Ok(result, "GetStatusesAsync Success");
    }

    [HttpGet("steps")]
    public async Task<IActionResult> GetStepsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _service.GetStepsAsync(cancellationToken);
        return Result.Ok(result, "GetStepsAsync Success");
    }

    [HttpGet("car-froms")]
    public async Task<IActionResult> GetCarFromsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _service.GetCarFromsAsync(cancellationToken);
        return Result.Ok(result, "GetCarFromsAsync Success");
    }

    [HttpGet("car-types")]
    public async Task<IActionResult> GetCarTypesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _service.GetCarTypesAsync(cancellationToken);
        return Result.Ok(result, "GetCarTypesAsync Success");
    }

    [HttpGet("car-comps")]
    public async Task<IActionResult> GetCarCompsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _service.GetCarCompsAsync(cancellationToken);
        return Result.Ok(result, "GetCarCompsAsync Success");
    }

    [HttpGet("io-categories")]
    public async Task<IActionResult> GetIoCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _service.GetIoCategoriesAsync(cancellationToken);
        return Result.Ok(result, "GetIoCategoriesAsync Success");
    }
}