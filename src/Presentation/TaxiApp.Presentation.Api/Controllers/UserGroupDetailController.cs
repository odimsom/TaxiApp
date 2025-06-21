using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Presentation.Api.Controllers.Common;

namespace TaxiApp.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupDetailController : GenericController<UserGroupDetailDto, UserGroupDetail>
    {
        public UserGroupDetailController(IGenericService<UserGroupDetailDto, UserGroupDetail> service) : base(service)
        {
        }
    }
}
