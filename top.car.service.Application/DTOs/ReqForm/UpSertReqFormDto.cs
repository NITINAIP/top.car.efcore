namespace top.car.service.Application.DTOs.ReqForm;

public class UpSertReqFormDto
{

    public string DocumentNo { get; set; } = string.Empty;
    public string ReqUserName { get; set; } = string.Empty;

    public string? ReqUserDisplay { get; set; }

    public string? ReqIdicator { get; set; }

    public string? ReqTelNumber { get; set; }
    public string? OnBehalfOf { get; set; }

    public string? ObhEmpId { get; set; }

    public string? ObhUserName { get; set; }

    public string? ObhIdicator { get; set; }

    public string? ObhTelNumber { get; set; }

    public string? ProjectWork { get; set; }

    public string? AccountCode { get; set; }

    public string? CostCenter { get; set; }

    public string? IoNo { get; set; }

    public decimal? CostComp { get; set; }

    public List<CarsDetailReqDto> CarsDetails { get; set; } = [];

}