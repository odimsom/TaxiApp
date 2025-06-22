using Microsoft.AspNetCore.Mvc;
using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Presentation.Web.Controllers.Common;

namespace TaxiApp.Presentation.WebAppBlazor.Controllers;

public class UserController : GenericController<UserDto, User>
{
    public UserController(IGenericService<UserDto, User> service) : base(service)
    {
    }
}