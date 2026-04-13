using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_MT_COMP")]
public class CarsMtComp : BaseEntityWithId
{
    [Column("COMP_CODE")]
    public string? CompCode { get; set; }
    [Column("COMP_SHORT_NAME")]
    public string? CompShortName { get; set; }
    [Column("COMP_NAME")]
    public string? CompName { get; set; }
    [Column("ORDER_BY")]
    public int? OrderBy { get; set; }
}
