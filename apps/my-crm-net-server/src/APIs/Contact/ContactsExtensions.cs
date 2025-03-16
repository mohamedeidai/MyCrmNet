using MyCrmNet.APIs.Dtos;
using MyCrmNet.Infrastructure.Models;

namespace MyCrmNet.APIs.Extensions;

public static class ContactsExtensions
{
    public static Contact ToDto(this ContactDbModel model)
    {
        return new Contact
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            TenantCode = model.TenantCode,
            TenantId = model.TenantId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ContactDbModel ToModel(
        this ContactUpdateInput updateDto,
        ContactWhereUniqueInput uniqueId
    )
    {
        var contact = new ContactDbModel
        {
            Id = uniqueId.Id,
            TenantCode = updateDto.TenantCode,
            TenantId = updateDto.TenantId
        };

        if (updateDto.CreatedAt != null)
        {
            contact.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            contact.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return contact;
    }
}
