using Microsoft.AspNetCore.Mvc;

namespace MyCrmNet.APIs;

[ApiController()]
public class LeadsController : LeadsControllerBase
{
    public LeadsController(ILeadsService service)
        : base(service) { }
}
