using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("BZ_MASTER_IO")]
public class BzMasterIo : BaseEntityWithString
{
    [Column("IO")]
    public override string Id { get; set; } = "";
    [Column("IO_DESC")]
    public string? IoDesc { get; set; }
    [Column("IO_TYPE")]
    public string? IoType { get; set; }
    [Column("COST_CENTER_RESP")]
    public string? CostCenterResp { get; set; }
    [Column("COM_CODE")]
    public string? ComCode { get; set; }
    [Column("CURRENCY")]
    public string? Currency { get; set; }
    [Column("IO_CATE")]
    public string? IoCate { get; set; }
    [Column("TOKEN")]
    public string? Token { get; set; }
    [Column("USERSTATUS")]
    public int? Userstatus { get; set; }
}
