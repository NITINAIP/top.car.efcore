using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
public abstract class BaseEntityWithString : BaseEntity
{
    [Column("ID")]
    public virtual string Id { get; set; } = Guid.NewGuid().ToString();
}