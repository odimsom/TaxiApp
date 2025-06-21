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
    public class TripDetailController : GenericController<TripDetailDto, TripDetail>
    {
        public TripDetailController(IGenericService<TripDetailDto, TripDetail> service) : base(service)
        {
        }
    }
}
