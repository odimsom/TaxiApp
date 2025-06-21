using TaxiApp.Core.Domain.Common;

namespace TaxiApp.Core.Domain.Entities;

public class Trip : BasicEntity<int>
{
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
    public int? Rating { get; set; }
    public required int UserId { get; set; }
    
    // Navigate Properties
    public User? User { get; set; }
    public Taxi? Taxi { get; set; }
    public ICollection<TripDetail>? TripDetails { get; set; }
}