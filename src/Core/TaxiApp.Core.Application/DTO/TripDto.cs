using TaxiApp.Core.Application.DTO.Common;

namespace TaxiApp.Core.Application.DTO;

public class TripDto : BasicDto<int>
{
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
    public int? Rating { get; set; }
    public required int UserId { get; set; }
    
    // Navigate Properties
    public UserDto? User { get; set; }
    public TaxiDto? Taxi { get; set; }
    public ICollection<TripDetailDto>? TripDetails { get; set; }
}