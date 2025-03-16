using Microsoft.AspNetCore.Mvc;
using MyCrmNet.APIs.Common;
using MyCrmNet.Infrastructure.Models;

namespace MyCrmNet.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class CustomerFindManyArgs : FindManyInput<Customer, CustomerWhereInput> { }
