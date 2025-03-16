using MyCrmNet.APIs.Common;
using MyCrmNet.APIs.Dtos;

namespace MyCrmNet.APIs;

public interface ILeadsService
{
    /// <summary>
    /// Create one Lead
    /// </summary>
    public Task<Lead> CreateLead(LeadCreateInput lead);

    /// <summary>
    /// Delete one Lead
    /// </summary>
    public Task DeleteLead(LeadWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Leads
    /// </summary>
    public Task<List<Lead>> Leads(LeadFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Lead records
    /// </summary>
    public Task<MetadataDto> LeadsMeta(LeadFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Lead
    /// </summary>
    public Task<Lead> Lead(LeadWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Lead
    /// </summary>
    public Task UpdateLead(LeadWhereUniqueInput uniqueId, LeadUpdateInput updateDto);
}
