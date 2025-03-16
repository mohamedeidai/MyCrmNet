using Microsoft.AspNetCore.Mvc;

namespace MyCrmNet.APIs;

[ApiController()]
public class OpportunitiesController : OpportunitiesControllerBase
{
    public OpportunitiesController(IOpportunitiesService service)
        : base(service) { }
}
