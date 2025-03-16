using MyCrmNet.Infrastructure;

namespace MyCrmNet.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(MyCrmNetDbContext context)
        : base(context) { }
}
