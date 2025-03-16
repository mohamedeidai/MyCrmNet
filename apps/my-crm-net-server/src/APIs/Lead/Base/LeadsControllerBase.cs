using Microsoft.AspNetCore.Mvc;
using MyCrmNet.APIs;
using MyCrmNet.APIs.Common;
using MyCrmNet.APIs.Dtos;
using MyCrmNet.APIs.Errors;

namespace MyCrmNet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class LeadsControllerBase : ControllerBase
{
    protected readonly ILeadsService _service;

    public LeadsControllerBase(ILeadsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Lead
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Lead>> CreateLead(LeadCreateInput input)
    {
        var lead = await _service.CreateLead(input);

        return CreatedAtAction(nameof(Lead), new { id = lead.Id }, lead);
    }

    /// <summary>
    /// Delete one Lead
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteLead([FromRoute()] LeadWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteLead(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Leads
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Lead>>> Leads([FromQuery()] LeadFindManyArgs filter)
    {
        return Ok(await _service.Leads(filter));
    }

    /// <summary>
    /// Meta data about Lead records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> LeadsMeta([FromQuery()] LeadFindManyArgs filter)
    {
        return Ok(await _service.LeadsMeta(filter));
    }

    /// <summary>
    /// Get one Lead
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Lead>> Lead([FromRoute()] LeadWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Lead(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Lead
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateLead(
        [FromRoute()] LeadWhereUniqueInput uniqueId,
        [FromQuery()] LeadUpdateInput leadUpdateDto
    )
    {
        try
        {
            await _service.UpdateLead(uniqueId, leadUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
