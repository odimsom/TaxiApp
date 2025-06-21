using TaxiApp.Core.Application.DTO.Common;

namespace TaxiApp.Core.Application.DTO;

public class TaxiDto : BasicDto<int>
{
    public string? Plate { get; set; }
    public int TripId { get; set; }
    
    // Navigate Properties 
    public TripDto? Trip { get; set; }
}