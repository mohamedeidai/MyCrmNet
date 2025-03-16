using MyCrmNet.APIs.Dtos;
using MyCrmNet.Infrastructure.Models;

namespace MyCrmNet.APIs.Extensions;

public static class OpportunitiesExtensions
{
    public static Opportunity ToDto(this OpportunityDbModel model)
    {
        return new Opportunity
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            TenantCode = model.TenantCode,
            TenantId = model.TenantId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static OpportunityDbModel ToModel(
        this OpportunityUpdateInput updateDto,
        OpportunityWhereUniqueInput uniqueId
    )
    {
        var opportunity = new OpportunityDbModel
        {
            Id = uniqueId.Id,
            TenantCode = updateDto.TenantCode,
            TenantId = updateDto.TenantId
        };

        if (updateDto.CreatedAt != null)
        {
            opportunity.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            opportunity.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return opportunity;
    }
}
