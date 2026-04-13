using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_CALENDAR_EVENT")]
public class CarsCalendarEvent : BaseEntityWithId
{
    [Column("ITEM_NO")]
    public int? ItemNo { get; set; }
    [Column("DOC_NO")]
    public string? DocNo { get; set; }
    [Column("BOOKING_ID")]
    public int? BookingId { get; set; }
    [Column("DRIVER_CODE")]
    public string? DriverCode { get; set; }
    [Column("DRIVER_NAME")]
    public string? DriverName { get; set; }
    [Column("DATE_START")]
    public string? DateStart { get; set; }
    [Column("DATE_END")]
    public string? DateEnd { get; set; }
    [Column("LOCATION_FROM")]
    public string? LocationFrom { get; set; }
    [Column("LOCATION_TO")]
    public string? LocationTo { get; set; }
    [Column("TIME_START")]
    public string? TimeStart { get; set; }
    [Column("TIME_END")]
    public string? TimeEnd { get; set; }
    [Column("TRANSPORT_TYPE")]
    public int? TransportType { get; set; }
    [Column("TRAVELOR_ID")]
    public string? TravelorId { get; set; }
    [Column("TRAVELOR_NAME")]
    public string? TravelorName { get; set; }
    [Column("TEL_NUMBER")]
    public string? TelNumber { get; set; }
    [Column("DETAIL")]
    public string? Detail { get; set; }
    [Column("CARCOMP_CODE")]
    public int? CarcompCode { get; set; }
    [Column("BOOKING_ITEM_NO")]
    public int? BookingItemNo { get; set; }
    [Column("ASSIGN_ROUTE")]
    public int? AssignRoute { get; set; }
}
