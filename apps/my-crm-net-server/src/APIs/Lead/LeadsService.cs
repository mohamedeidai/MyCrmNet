using MyCrmNet.Infrastructure;

namespace MyCrmNet.APIs;

public class LeadsService : LeadsServiceBase
{
    public LeadsService(MyCrmNetDbContext context)
        : base(context) { }
}
