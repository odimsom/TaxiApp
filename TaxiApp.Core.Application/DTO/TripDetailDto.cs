using TaxiApp.Core.Application.DTO.Common;

namespace TaxiApp.Core.Application.DTO;

public class TripDetailDto : BasicDto<int>
{
    public string? Longitude { get; set; }
    public string? Latitude { get; set; }
    public required DateTime Date { get; set; }
    public required int TripId { get; set; }
    
    // Navigate properties 
    public TripDto? Trip { get; set; }
}