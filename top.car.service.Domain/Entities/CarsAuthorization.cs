using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_AUTHORIZATION")]
public class CarsAuthorization : BaseEntityWithId
{
    [Column("USERNAME")]
    public string? Username { get; set; }
    [Column("SUPER_ADMIN")]
    public string? SuperAdmin { get; set; }
    [Column("PMSV_ADMIN")]
    public string? PmsvAdmin { get; set; }
    [Column("GSBO_ADMIN")]
    public string? GsboAdmin { get; set; }
    [Column("TEMP_2")]
    public string? Temp2 { get; set; }
    [Column("TEMP_3")]
    public string? Temp3 { get; set; }
}
