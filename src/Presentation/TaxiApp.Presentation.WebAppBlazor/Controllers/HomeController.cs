using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Application.DTO.WebApp;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Presentation.WebAppBlazor.Models;

namespace TaxiApp.Presentation.WebAppBlazor.Controllers;

public class HomeController : Controller
{
    private readonly IGenericService<TaxiDto, Taxi> _taxiService;
    private readonly IGenericService<TripDto, Trip> _tripService;
    private readonly IGenericService<UserDto, User> _userService;

    public HomeController(
        IGenericService<TaxiDto, Taxi> taxiService,
        IGenericService<TripDto, Trip> tripService,
        IGenericService<UserDto, User> userService)
    {
        _taxiService = taxiService;
        _tripService = tripService;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var dashboard = new HomeDashboardDto();

        var taxisResult = await _taxiService.GetAllIncludeAsync(new[] { "Trip" });
        if (taxisResult.IsSuccess)
        {
            dashboard.TotalTaxis = taxisResult.Data.Count;
            dashboard.TaxisEnViaje = taxisResult.Data.Count(t => t.Trip != null && t.Trip.EndDate > DateTime.Now);
        }

        var tripsResult = await _tripService.GetAllIncludeAsync(new[] { "User", "Taxi" });
        if (tripsResult.IsSuccess)
        {
            var tripsThisMonth = tripsResult.Data.Where(t => t.StartDate.Month == DateTime.Now.Month);
            dashboard.TotalTripsMes = tripsThisMonth.Count();
            dashboard.TripsEnCurso = tripsResult.Data.Count(t => t.EndDate > DateTime.Now);

            dashboard.UltimosViajes = tripsThisMonth
                .OrderByDescending(t => t.StartDate)
                .Take(5)
                .Select(t => new TripSummaryDto
                {
                    Id = t.Id,
                    TaxiPlate = t.Taxi?.Plate ?? "N/A",
                    UsuarioNombre = t.User != null ? $"{t.User.FirstName} {t.User.LastName}" : "N/A",
                    StartDate = t.StartDate,
                    Estado = t.EndDate > DateTime.Now ? "En Curso" : "Completado"
                })
                .ToList();
        }

        var usersResult = await _userService.GetAllAsync();
        if (usersResult.IsSuccess)
        {
            dashboard.TotalUsuarios = usersResult.Data.Count;
        }

        return View(dashboard);
    }


}
