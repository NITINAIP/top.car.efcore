using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("BZ_USERS")]
public class BzUsers : BaseEntityWithString
{
    [Column("EMPLOYEEID")]
    public override string Id { get; set; } = "";
    [Column("USERID")]
    public string? Userid { get; set; }
    [Column("COMPANYCODE")]
    public string? Companycode { get; set; }
    [Column("FUNCTION")]
    public string? Function { get; set; }
    [Column("DEPARTMENT")]
    public string? Department { get; set; }
    [Column("DIVISION")]
    public string? Division { get; set; }
    [Column("SECTIONS")]
    public string? Sections { get; set; }
    [Column("UNITS")]
    public string? Units { get; set; }
    [Column("ORGID")]
    public string? Orgid { get; set; }
    [Column("POSID")]
    public string? Posid { get; set; }
    [Column("OBJENFULLNAME")]
    public string? Objenfullname { get; set; }
    [Column("OBJTHFULLNAME")]
    public string? Objthfullname { get; set; }
    [Column("POSCAT")]
    public string? Poscat { get; set; }
    [Column("EMPSTATUS")]
    public string? Empstatus { get; set; }
    [Column("EMPCAT")]
    public string? Empcat { get; set; }
    [Column("PERSAREA")]
    public string? Persarea { get; set; }
    [Column("PERSUBAREA")]
    public string? Persubarea { get; set; }
    [Column("EMPGROUP")]
    public string? Empgroup { get; set; }
    [Column("EMPSUBGROUP")]
    public string? Empsubgroup { get; set; }
    [Column("THNAME")]
    public string? Thname { get; set; }
    [Column("THTITLE")]
    public string? Thtitle { get; set; }
    [Column("THFIRSTNAME")]
    public string? Thfirstname { get; set; }
    [Column("THLASTNAME")]
    public string? Thlastname { get; set; }
    [Column("ENTITLE")]
    public string? Entitle { get; set; }
    [Column("ENFIRSTNAME")]
    public string? Enfirstname { get; set; }
    [Column("ENLASTNAME")]
    public string? Enlastname { get; set; }
    [Column("GENDER")]
    public string? Gender { get; set; }
    [Column("REFERENCEID")]
    public string? Referenceid { get; set; }
    [Column("EMAIL")]
    public string? Email { get; set; }
    [Column("SUPERVISOR")]
    public string? Supervisor { get; set; }
    [Column("MANAGERIAL")]
    public string? Managerial { get; set; }
    [Column("CONTRACT")]
    public string? Contract { get; set; }
    [Column("HOLDERPOSITION")]
    public string? Holderposition { get; set; }
    [Column("REPORTTOPOS")]
    public string? Reporttopos { get; set; }
    [Column("REPORTTOID")]
    public string? Reporttoid { get; set; }
    [Column("REPORTTONAME")]
    public string? Reporttoname { get; set; }
    [Column("REPORTTOEMAIL")]
    public string? Reporttoemail { get; set; }
    [Column("TOKEN")]
    public string? Token { get; set; }
    [Column("IMGURL")]
    public string? Imgurl { get; set; }
    [Column("ORGNAME")]
    public string? Orgname { get; set; }
    [Column("MANAGER_EMPID")]
    public string? ManagerEmpid { get; set; }
    [Column("SH")]
    public string? Sh { get; set; }
    [Column("VP")]
    public string? Vp { get; set; }
    [Column("AEP")]
    public string? Aep { get; set; }
    [Column("EVP")]
    public string? Evp { get; set; }
    [Column("SEVP")]
    public string? Sevp { get; set; }
    [Column("CEO")]
    public string? Ceo { get; set; }
    [Column("COSTCENTER")]
    public string? Costcenter { get; set; }
    [Column("USERSTATUS")]
    public int? Userstatus { get; set; }
    [Column("ACTION")]
    public string? Action { get; set; }
    [Column("ACTION_DATE")]
    public string? ActionDate { get; set; }
    [Column("ROLE_ID")]
    public int? RoleId { get; set; }
    [Column("EMPPOS")]
    public string? Emppos { get; set; }
    [Column("ORDERWBS")]
    public string? Orderwbs { get; set; }
    [Column("GLACCOUNT")]
    public string? Glaccount { get; set; }
    [Column("USERTYPE")]
    public string? Usertype { get; set; }
    [Column("HIREDATE")]
    public string? Hiredate { get; set; }
}
