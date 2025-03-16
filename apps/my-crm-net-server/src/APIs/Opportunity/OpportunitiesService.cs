using MyCrmNet.Infrastructure;

namespace MyCrmNet.APIs;

public class OpportunitiesService : OpportunitiesServiceBase
{
    public OpportunitiesService(MyCrmNetDbContext context)
        : base(context) { }
}
