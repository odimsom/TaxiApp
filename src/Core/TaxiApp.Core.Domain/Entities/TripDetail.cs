using TaxiApp.Core.Domain.Common;

namespace TaxiApp.Core.Domain.Entities;

public class TripDetail : BasicEntity<int>
{
    public string? Longitude { get; set; }
    public string? Latitude { get; set; }
    public required DateTime Date { get; set; }
    public required int TripId { get; set; }
    
    // Navigate properties 
    public Trip? Trip { get; set; }
}