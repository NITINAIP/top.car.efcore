using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;
[Table("CARS_USER_PROFILE")]
public class CarsUserProfile : BaseEntityWithId
{
    [Column("USERNAME")]
    public string? Username { get; set; }
    [Column("EMP_ID")]
    public string? EmpId { get; set; }
    [Column("ADDRESS")]
    public string? Address { get; set; }
    [Column("ADDRESS_URL")]
    public string? AddressUrl { get; set; }
    [Column("TEL_NO")]
    public string? TelNo { get; set; }
    [Column("IMG_NAME")]
    public string? ImgName { get; set; }
    [Column("IMG_PATH")]
    public string? ImgPath { get; set; }
    [Column("STATUS_UPLOAD_IMG")]
    public string? StatusUploadImg { get; set; }
    [Column("ADDRESS2")]
    public string? Address2 { get; set; }
    [Column("ADDRESS3")]
    public string? Address3 { get; set; }
    [Column("ADDRESS4")]
    public string? Address4 { get; set; }
}
