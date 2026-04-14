using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_DETAIL_TRAVELER")]
public class CarsDetailTraveler : BaseEntityWithId
{
    [Column("BOOKING_ID")]
    public int BookingId { get; set; }
    [Column("ITEM_NO_BOOKING")]
    public int? ItemNoBooking { get; set; }
    [Column("NO_DISP")]
    public int? NoDisp { get; set; }
    [Column("UMS_ID")]
    public string? UmsId { get; set; }
    [Column("UMS_USERNAME")]
    public string? UmsUsername { get; set; }
    [Column("TEL_NUMBER")]
    public string? TelNumber { get; set; }

    public CarsDetailBooking? CarsDetailBooking { get; set; }
}
