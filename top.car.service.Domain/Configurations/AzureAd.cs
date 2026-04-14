namespace top.car.service.Domain.Configurations;
public class AzureAd
{
    public string Instance { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string GraphScope { get; set; } = string.Empty;

}
