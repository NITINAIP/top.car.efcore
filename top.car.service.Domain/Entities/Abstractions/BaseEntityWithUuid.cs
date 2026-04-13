using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
public abstract class BaseEntityWithUuid : BaseEntity
{
    [Column("ID")]
    public virtual string Id { get; set; } = Guid.NewGuid().ToString();
}