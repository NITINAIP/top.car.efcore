using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_ROUTE")]
public class CarsRoute : BaseEntityWithId
{
    [Column("ITEM_NO")]
    public int ItemNo { get; set; }
    [Column("ROUTE")]
    public int? Route { get; set; }
    [Column("CARCOMP_CODE")]
    public int? CarcompCode { get; set; }
    [Column("CARCOMP_NAME")]
    public string? CarcompName { get; set; }
    [Column("DRIVER_CODE")]
    public int? DriverCode { get; set; }
    [Column("DRIVER_NAME")]
    public string? DriverName { get; set; }
    [Column("CARS_TYPE_NAME")]
    public string? CarsTypeName { get; set; }
    [Column("CAR_MODEL")]
    public string? CarModel { get; set; }
    [Column("CAR_COLOR")]
    public string? CarColor { get; set; }
    [Column("VEHICLE_REGISTRATION")]
    public string? VehicleRegistration { get; set; }
    [Column("TEL_NUMBER")]
    public string? TelNumber { get; set; }
    [Column("ORDER_BY")]
    public int? OrderBy { get; set; }
    [Column("TEMP_1")]
    public string? Temp1 { get; set; }
    [Column("TEMP_2")]
    public string? Temp2 { get; set; }
    [Column("TEMP_3")]
    public string? Temp3 { get; set; }
}
