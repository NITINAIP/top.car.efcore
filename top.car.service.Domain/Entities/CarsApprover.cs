using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_APPROVER")]
public class CarsApprover : BaseEntityWithId
{
    [Column("APPROVER_USERNAME")]
    public string? ApproverUsername { get; set; }
    [Column("APPROVER_ACTION")]
    public int? ApproverAction { get; set; }
    [Column("APPROVER_REASON")]
    public string? ApproverReason { get; set; }
    [Column("APPROVER_ACTION_DATE")]
    public string? ApproverActionDate { get; set; }
    [Column("ADMIN_USERNAME")]
    public string? AdminUsername { get; set; }
    [Column("ADMIN_ACTION")]
    public int? AdminAction { get; set; }
    [Column("ADMIN_REASON")]
    public string? AdminReason { get; set; }
    [Column("ADMIN_ACTION_DATE")]
    public string? AdminActionDate { get; set; }
}
