using Microsoft.AspNetCore.Mvc;

namespace MyCrmNet.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
