using TaxiApp.Core.Domain.Common;

namespace TaxiApp.Core.Domain.Entities;

public class User : BasicEntity<int>
{
    public required string DocumentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public ICollection<UserGroupDetail>? UserGroupDetails { get; set; }
    public ICollection<Trip>? Trips { get; set; }
}