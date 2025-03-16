using MyCrmNet.APIs.Common;
using MyCrmNet.APIs.Dtos;

namespace MyCrmNet.APIs;

public interface IOpportunitiesService
{
    /// <summary>
    /// Create one Opportunity
    /// </summary>
    public Task<Opportunity> CreateOpportunity(OpportunityCreateInput opportunity);

    /// <summary>
    /// Delete one Opportunity
    /// </summary>
    public Task DeleteOpportunity(OpportunityWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Opportunities
    /// </summary>
    public Task<List<Opportunity>> Opportunities(OpportunityFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Opportunity records
    /// </summary>
    public Task<MetadataDto> OpportunitiesMeta(OpportunityFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Opportunity
    /// </summary>
    public Task<Opportunity> Opportunity(OpportunityWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Opportunity
    /// </summary>
    public Task UpdateOpportunity(
        OpportunityWhereUniqueInput uniqueId,
        OpportunityUpdateInput updateDto
    );
}
