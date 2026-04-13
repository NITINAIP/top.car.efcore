using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("BZ_MASTER_GL")]
public class BzMasterGl : BaseEntityWithString
{
    [Column("GL_NO")]
    public override string Id { get; set; } = "";
    [Column("GL_DESC")]
    public string? GlDesc { get; set; }
    [Column("TOKEN")]
    public string? Token { get; set; }
    [Column("USERSTATUS")]
    public int? Userstatus { get; set; }

}