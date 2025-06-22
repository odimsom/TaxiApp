using Microsoft.AspNetCore.Mvc;
using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Application.Interfaces;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Presentation.Web.Controllers.Common;

namespace TaxiApp.Presentation.WebAppBlazor.Controllers;

public class TripDetailController : GenericController<TripDetailDto, TripDetail>
{
    public TripDetailController(ITripDetailService service) : base(service)
    {
    }
}