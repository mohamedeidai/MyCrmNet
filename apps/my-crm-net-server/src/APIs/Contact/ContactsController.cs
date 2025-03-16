using Microsoft.AspNetCore.Mvc;

namespace MyCrmNet.APIs;

[ApiController()]
public class ContactsController : ContactsControllerBase
{
    public ContactsController(IContactsService service)
        : base(service) { }
}
