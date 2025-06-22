using Microsoft.AspNetCore.Mvc;
using TaxiApp.Core.Application.DTO;
using TaxiApp.Core.Application.Interfaces;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Domain.Entities;
using TaxiApp.Presentation.Web.Controllers.Common;

namespace TaxiApp.Presentation.WebAppBlazor.Controllers;

public class TripController : GenericController<TripDto, Trip>
{
    private readonly ITripService _tripService;
    private readonly ITripDetailService _tripDetailService;
    public TripController(ITripService service, ITripDetailService tripDetailService) : base(service)
    {
        _tripService = service;
        _tripDetailService = tripDetailService;
    }
    
    [HttpPost]
    public async Task<IActionResult> GenerateTripDetails(int tripId)
    {
        var tripResult = await _tripService.GetByIdAsync(tripId);
        if (!tripResult.IsSuccess || tripResult.Data == null)
            return BadRequest("Trip not found");

        var trip = tripResult.Data;

        var generatedDetails = new List<TripDetailDto>();

        var totalPoints = 5;
        var start = trip.StartDate;
        var end = trip.EndDate;
        var interval = (end - start).TotalMinutes / (totalPoints - 1);

        for (int i = 0; i < totalPoints; i++)
        {
            var date = start.AddMinutes(interval * i);

            var longitude = (i * 1.0).ToString("F6");  
            var latitude = (i * 1.0).ToString("F6");

            generatedDetails.Add(new TripDetailDto
            {
                Id = trip.Id,
                Date = date,
                Longitude = longitude,
                Latitude = latitude,
                TripId = tripId
            });
        }

        var saveResult = await _tripDetailService.AddRangeAsync(generatedDetails);
        if (!saveResult.IsSuccess)
            return BadRequest(saveResult.Message);

        return RedirectToAction("Details", new { id = tripId });
    }

}