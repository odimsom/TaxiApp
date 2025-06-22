using Microsoft.AspNetCore.Mvc;
using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Presentation.Web.Controllers.Common;

namespace TaxiApp.Presentation.WebAppBlazor.Controllers;

public class UserGroupDetailController : GenericController<UserGroupDetailDto, UserGroupDetail>
{
    public UserGroupDetailController(IGenericService<UserGroupDetailDto, UserGroupDetail> service) : base(service)
    {
    }
}