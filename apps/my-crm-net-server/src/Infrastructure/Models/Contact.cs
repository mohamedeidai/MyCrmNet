using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCrmNet.Infrastructure.Models;

[Table("Contacts")]
public class ContactDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? TenantCode { get; set; }

    [StringLength(1000)]
    public string? TenantId { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
