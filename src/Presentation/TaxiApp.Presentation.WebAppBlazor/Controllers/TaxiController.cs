using Microsoft.AspNetCore.Mvc;
using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Presentation.Web.Controllers.Common;

namespace TaxiApp.Presentation.WebAppBlazor.Controllers;

public class TaxiController : GenericController<TaxiDto, Taxi>
{
    public TaxiController(IGenericService<TaxiDto, Taxi> service) : base(service)
    {
    }
}