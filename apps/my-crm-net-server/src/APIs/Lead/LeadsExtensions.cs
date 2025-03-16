using MyCrmNet.APIs.Dtos;
using MyCrmNet.Infrastructure.Models;

namespace MyCrmNet.APIs.Extensions;

public static class LeadsExtensions
{
    public static Lead ToDto(this LeadDbModel model)
    {
        return new Lead
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            TenantCode = model.TenantCode,
            TenantId = model.TenantId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static LeadDbModel ToModel(this LeadUpdateInput updateDto, LeadWhereUniqueInput uniqueId)
    {
        var lead = new LeadDbModel
        {
            Id = uniqueId.Id,
            TenantCode = updateDto.TenantCode,
            TenantId = updateDto.TenantId
        };

        if (updateDto.CreatedAt != null)
        {
            lead.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            lead.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return lead;
    }
}
