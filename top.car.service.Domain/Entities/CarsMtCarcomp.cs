using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_MT_CARCOMP")]
public class CarsMtCarcomp : BaseEntityWithId
{
    [Column("NAME")]
    public string? Name { get; set; }
    [Column("SHORT_NAME")]
    public string? ShortName { get; set; }
    [Column("CARS_FROM")]
    public string? CarsFrom { get; set; }
    [Column("COORDINATOR")]
    public string? Coordinator { get; set; }
    [Column("EMAIL")]
    public string? Email { get; set; }
    [Column("ORDER_BY")]
    public int? OrderBy { get; set; }
    [Column("TEL_NO")]
    public string? TelNo { get; set; }
}
