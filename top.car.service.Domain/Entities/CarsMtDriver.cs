using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_MT_DRIVER")]
public class CarsMtDriver : BaseEntityWithId
{
    [Column("CARCOMP_CODE")]
    public int? CarcompCode { get; set; }
    [Column("CARS_FROM")]
    public string? CarsFrom { get; set; }
    [Column("DRIVER_CODE")]
    public string? DriverCode { get; set; }
    [Column("DRIVER_NAME")]
    public string? DriverName { get; set; }
    [Column("CARS_TYPE")]
    public int? CarsType { get; set; }
    [Column("CAR_MODEL")]
    public string? CarModel { get; set; }
    [Column("CAR_COLOR")]
    public string? CarColor { get; set; }
    [Column("VEHICLE_REGISTRATION")]
    public string? VehicleRegistration { get; set; }
    [Column("TEL_NUMBER")]
    public string? TelNumber { get; set; }
    [Column("TEMP_1")]
    public string? Temp1 { get; set; }
    [Column("TEMP_2")]
    public string? Temp2 { get; set; }
    [Column("TEMP_3")]
    public string? Temp3 { get; set; }
    [Column("INACTIVE")]
    public string? Inactive { get; set; }
}
