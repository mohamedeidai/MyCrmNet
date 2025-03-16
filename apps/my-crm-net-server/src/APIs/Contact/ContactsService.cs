using MyCrmNet.Infrastructure;

namespace MyCrmNet.APIs;

public class ContactsService : ContactsServiceBase
{
    public ContactsService(MyCrmNetDbContext context)
        : base(context) { }
}
