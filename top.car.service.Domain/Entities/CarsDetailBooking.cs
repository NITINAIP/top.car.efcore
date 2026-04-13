using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_DETAIL_BOOKING")]
public class CarsDetailBooking : BaseEntityWithId
{
    [Column("ITEM_NO")]
    public int? ItemNo { get; set; }
    [Column("CAR_TYPE")]
    public int? CarType { get; set; }
    [Column("REQ_TYPE")]
    public int? ReqType { get; set; }
    [Column("BUSINESS_DOC_NO")]
    public string? BusinessDocNo { get; set; }
    [Column("REQ_FOR")]
    public string? ReqFor { get; set; }
    [Column("REQ_FROM")]
    public int? ReqFrom { get; set; }
    [Column("USE_DATE_FROM")]
    public string? UseDateFrom { get; set; }
    [Column("USE_DATE_TO")]
    public string? UseDateTo { get; set; }
    [Column("USE_TIME_FROM")]
    public string? UseTimeFrom { get; set; }
    [Column("USE_TIME_TO")]
    public string? UseTimeTo { get; set; }
    [Column("LOCATION_FROM")]
    public string? LocationFrom { get; set; }
    [Column("LOCATON_FROM_URL")]
    public string? LocatonFromUrl { get; set; }
    [Column("LOCATON_TO")]
    public string? LocatonTo { get; set; }
    [Column("LOCATON_TO_URL")]
    public string? LocatonToUrl { get; set; }
    [Column("TRANSPORT_TYPE")]
    public int? TransportType { get; set; }
    [Column("TRANSPORT_DETAIL")]
    public string? TransportDetail { get; set; }
    [Column("ORDER_BY")]
    public int? OrderBy { get; set; }
}
