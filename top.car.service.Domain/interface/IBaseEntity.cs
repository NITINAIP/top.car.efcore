namespace top.car.service.Domain.Interface;
public interface IBaseEntity
{
    public string CreatedDate { get; set; }
    public string? UpdatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}