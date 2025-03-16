using Microsoft.EntityFrameworkCore;
using MyCrmNet.APIs;
using MyCrmNet.APIs.Common;
using MyCrmNet.APIs.Dtos;
using MyCrmNet.APIs.Errors;
using MyCrmNet.APIs.Extensions;
using MyCrmNet.Infrastructure;
using MyCrmNet.Infrastructure.Models;

namespace MyCrmNet.APIs;

public abstract class LeadsServiceBase : ILeadsService
{
    protected readonly MyCrmNetDbContext _context;

    public LeadsServiceBase(MyCrmNetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Lead
    /// </summary>
    public async Task<Lead> CreateLead(LeadCreateInput createDto)
    {
        var lead = new LeadDbModel
        {
            CreatedAt = createDto.CreatedAt,
            TenantCode = createDto.TenantCode,
            TenantId = createDto.TenantId,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            lead.Id = createDto.Id;
        }

        _context.Leads.Add(lead);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<LeadDbModel>(lead.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Lead
    /// </summary>
    public async Task DeleteLead(LeadWhereUniqueInput uniqueId)
    {
        var lead = await _context.Leads.FindAsync(uniqueId.Id);
        if (lead == null)
        {
            throw new NotFoundException();
        }

        _context.Leads.Remove(lead);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Leads
    /// </summary>
    public async Task<List<Lead>> Leads(LeadFindManyArgs findManyArgs)
    {
        var leads = await _context
            .Leads.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return leads.ConvertAll(lead => lead.ToDto());
    }

    /// <summary>
    /// Meta data about Lead records
    /// </summary>
    public async Task<MetadataDto> LeadsMeta(LeadFindManyArgs findManyArgs)
    {
        var count = await _context.Leads.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Lead
    /// </summary>
    public async Task<Lead> Lead(LeadWhereUniqueInput uniqueId)
    {
        var leads = await this.Leads(
            new LeadFindManyArgs { Where = new LeadWhereInput { Id = uniqueId.Id } }
        );
        var lead = leads.FirstOrDefault();
        if (lead == null)
        {
            throw new NotFoundException();
        }

        return lead;
    }

    /// <summary>
    /// Update one Lead
    /// </summary>
    public async Task UpdateLead(LeadWhereUniqueInput uniqueId, LeadUpdateInput updateDto)
    {
        var lead = updateDto.ToModel(uniqueId);

        _context.Entry(lead).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Leads.Any(e => e.Id == lead.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
