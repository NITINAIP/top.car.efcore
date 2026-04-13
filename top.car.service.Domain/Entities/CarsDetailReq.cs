using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_DETAIL_REQ")]
public class CarsDetailReq : BaseEntityWithId
{
    [Column("DOC_NO")]
    public string? DocNo { get; set; }
    [Column("REQ_USER_NAME")]
    public string? ReqUserName { get; set; }
    [Column("REQ_USER_DISPLAY")]
    public string? ReqUserDisplay { get; set; }
    [Column("REQ_IDICATOR")]
    public string? ReqIdicator { get; set; }
    [Column("REQ_TEL_NUMBER")]
    public string? ReqTelNumber { get; set; }
    [Column("ON_BEHALF_OF")]
    public string? OnBehalfOf { get; set; }
    [Column("OBH_EMP_ID")]
    public string? ObhEmpId { get; set; }
    [Column("OBH_USER_NAME")]
    public string? ObhUserName { get; set; }
    [Column("OBH_IDICATOR")]
    public string? ObhIdicator { get; set; }
    [Column("OBH_TEL_NUMBER")]
    public string? ObhTelNumber { get; set; }
    [Column("PROJECT_WORK")]
    public string? ProjectWork { get; set; }
    [Column("ACCOUNT_CODE")]
    public string? AccountCode { get; set; }
    [Column("COST_CENTER")]
    public string? CostCenter { get; set; }
    [Column("IO_NO")]
    public string? IoNo { get; set; }
    [Column("COST_COMP")]
    public int? CostComp { get; set; }
}
