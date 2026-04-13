using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_WF_PROCESS")]
public class CarsWfProcess : BaseEntityWithId
{
    [Column("DOC_NO")]
    public string? DocNo { get; set; }
    [Column("CAR_TYPE")]
    public int? CarType { get; set; }
    [Column("YEAR")]
    public int? Year { get; set; }
    [Column("MONTH")]
    public int? Month { get; set; }
    [Column("RUNNING_NO")]
    public int? RunningNo { get; set; }
    [Column("STEP_FLOW")]
    public int? StepFlow { get; set; }
    [Column("STATUS_FLOW")]
    public int? StatusFlow { get; set; }
    [Column("CARS_FROM_CODE")]
    public string? CarsFromCode { get; set; }
    [Column("TEMP_2")]
    public string? Temp2 { get; set; }
    [Column("TEMP_3")]
    public string? Temp3 { get; set; }
}
