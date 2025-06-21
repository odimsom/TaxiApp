using TaxiApp.Core.Application.DTO.Common;

namespace TaxiApp.Core.Application.DTO;

public class UserDto : BasicDto<int>
{
    public required string DocumentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public ICollection<UserGroupDetailDto>? UserGroupDetails { get; set; }
    public ICollection<TripDto>? Trips { get; set; }
}