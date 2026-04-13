using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
public abstract class BaseEntityWithId : BaseEntity
{
    [Column("ID")]
    public virtual int Id { get; set; }
}