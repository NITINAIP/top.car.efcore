namespace top.car.service.Domain.Entities;
using top.car.service.Domain.Interface;
public abstract class BaseEntity : IBaseEntity
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; }
    public string? CreatedBy { get; set; } = "SYSTEM";
    public string? UpdatedBy { get; set; }
}