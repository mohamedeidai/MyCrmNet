namespace MyCrmNet.APIs.Dtos;

public class ContactUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? TenantCode { get; set; }

    public string? TenantId { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
