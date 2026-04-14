namespace top.car.service.Domain.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using top.car.service.Domain.Interface;
public abstract class BaseEntity : IBaseEntity
{
    [Column("CREATED_DATE")]
    public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

    [Column("UPDATED_DATE")]
    public string? UpdatedDate { get; set; }

    [Column("CREATED_BY")]
    public string? CreatedBy { get; set; } = "SYSTEM";

    [Column("UPDATED_BY")]
    public string? UpdatedBy { get; set; }
}