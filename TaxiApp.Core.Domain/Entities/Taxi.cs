using TaxiApp.Core.Domain.Common;

namespace TaxiApp.Core.Domain.Entities;

public class Taxi : BasicEntity<int>
{
    public string? Plate { get; set; }
    public int TripId { get; set; }
    
    // Navigate Properties 
    public Trip? Trip { get; set; }
}