namespace top.car.service.Application.DTOs.ReqForm;
public class ReqFormDto
{
    public string DocumentNo { get; set; } = string.Empty;
    public string? ReqUserName { get; set; }

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

public class CarsDetailReqDto
{
    public string? Id { get; set; }
    public int? ItemNo { get; set; }
    public int? CarType { get; set; }
    public string? ReqType { get; set; }
    public string? BusinessDoc { get; set; }
    public string? ReqFor { get; set; }
    public string? ReqFrom { get; set; }
    public string? UseDateFrom { get; set; }
    public string? UseDateTo { get; set; }
    public string? UseTimeFrom { get; set; }
    public string? UseTimeTo { get; set; }
    public string? UseDateStr { get; set; }
    public string? LocationFrom { get; set; }
    public string? LocatonFromUrl { get; set; }
    public string? LocatonTo { get; set; }
    public string? LocatonToUrl { get; set; }
    public string? TransportType { get; set; }
    public string? TransportDetail { get; set; }
    public string? Selected { get; set; }
    public string? OldItemNo { get; set; }
    public int? OrderBy { get; set; }

    public List<CarsDetailTravelerDto> Travelers { get; set; } = [];

}

public class CarsDetailTravelerDto
{
    public int? Id { get; set; }
    public int? ItemNoBooking { get; set; }
    public int? NoDisp { get; set; }
    public string? UmsId { get; set; }
    public string? UmsUsername { get; set; }
    public string? TelNumber { get; set; }
}