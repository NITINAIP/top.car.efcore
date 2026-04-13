using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_MT_STATUS")]
public class CarsMtStatus : BaseEntityWithId
{
    [Column("NAME")]
    public string? Name { get; set; }
    [Column("ORDER_BY")]
    public int? OrderBy { get; set; }
}
