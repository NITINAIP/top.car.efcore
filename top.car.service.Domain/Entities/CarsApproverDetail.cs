using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_APPROVER_DETAIL")]
public class CarsApproverDetail : BaseEntityWithId
{
    [Column("APPROVER_USERNAME")]
    public string? ApproverUsername { get; set; }
    [Column("APPROVER_ACTION")]
    public int? ApproverAction { get; set; }
    [Column("APPROVED_DATE")]
    public string? ApprovedDate { get; set; }
    [Column("ADMIN_ASSIGN_USERNAME")]
    public string? AdminAssignUsername { get; set; }
    [Column("ADMIN_ACTION")]
    public int? AdminAction { get; set; }
    [Column("ASSIGN_DATE")]
    public string? AssignDate { get; set; }
    [Column("SUBMIT_USERNAME")]
    public string? SubmitUsername { get; set; }
    [Column("SUBMIT_DATE")]
    public string? SubmitDate { get; set; }
}
