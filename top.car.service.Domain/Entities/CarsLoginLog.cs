using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_LOGIN_LOG")]
public class CarsLoginLog : BaseEntityWithId
{
    [Column("USERNAME")]
    public string? Username { get; set; }
    [Column("EMAIL")]
    public string? Email { get; set; }
    [Column("LOGIN_DATE")]
    public string? LoginDate { get; set; }
    [Column("USERDISPLAY")]
    public string? Userdisplay { get; set; }
}
