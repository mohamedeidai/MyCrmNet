using Microsoft.EntityFrameworkCore;
using MyCrmNet.APIs;
using MyCrmNet.APIs.Common;
using MyCrmNet.APIs.Dtos;
using MyCrmNet.APIs.Errors;
using MyCrmNet.APIs.Extensions;
using MyCrmNet.Infrastructure;
using MyCrmNet.Infrastructure.Models;

namespace MyCrmNet.APIs;

public abstract class ContactsServiceBase : IContactsService
{
    protected readonly MyCrmNetDbContext _context;

    public ContactsServiceBase(MyCrmNetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Contact
    /// </summary>
    public async Task<Contact> CreateContact(ContactCreateInput createDto)
    {
        var contact = new ContactDbModel
        {
            CreatedAt = createDto.CreatedAt,
            TenantCode = createDto.TenantCode,
            TenantId = createDto.TenantId,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            contact.Id = createDto.Id;
        }

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ContactDbModel>(contact.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Contact
    /// </summary>
    public async Task DeleteContact(ContactWhereUniqueInput uniqueId)
    {
        var contact = await _context.Contacts.FindAsync(uniqueId.Id);
        if (contact == null)
        {
            throw new NotFoundException();
        }

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Contacts
    /// </summary>
    public async Task<List<Contact>> Contacts(ContactFindManyArgs findManyArgs)
    {
        var contacts = await _context
            .Contacts.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return contacts.ConvertAll(contact => contact.ToDto());
    }

    /// <summary>
    /// Meta data about Contact records
    /// </summary>
    public async Task<MetadataDto> ContactsMeta(ContactFindManyArgs findManyArgs)
    {
        var count = await _context.Contacts.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Contact
    /// </summary>
    public async Task<Contact> Contact(ContactWhereUniqueInput uniqueId)
    {
        var contacts = await this.Contacts(
            new ContactFindManyArgs { Where = new ContactWhereInput { Id = uniqueId.Id } }
        );
        var contact = contacts.FirstOrDefault();
        if (contact == null)
        {
            throw new NotFoundException();
        }

        return contact;
    }

    /// <summary>
    /// Update one Contact
    /// </summary>
    public async Task UpdateContact(ContactWhereUniqueInput uniqueId, ContactUpdateInput updateDto)
    {
        var contact = updateDto.ToModel(uniqueId);

        _context.Entry(contact).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Contacts.Any(e => e.Id == contact.Id))
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
