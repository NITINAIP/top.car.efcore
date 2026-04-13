using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_FEEDBACK")]
public class CarsFeedback : BaseEntityWithId
{
    [Column("COMPLACENCY")]
    public int? Complacency { get; set; }
    [Column("COMPLACENCY_DESCRIPTION")]
    public string? ComplacencyDescription { get; set; }
    [Column("SUGGESTION")]
    public string? Suggestion { get; set; }
    [Column("TEMP_1")]
    public string? Temp1 { get; set; }
    [Column("TEMP_2")]
    public string? Temp2 { get; set; }
    [Column("TEMP_3")]
    public string? Temp3 { get; set; }
}
