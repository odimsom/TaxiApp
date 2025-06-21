using TaxiApp.Core.Domain.Common;

namespace TaxiApp.Core.Domain.Entities;

public class UserGroupDetail : BasicEntity<int>
{
    public required int UserId { get; set; }
    public required int UserGroupId { get; set; }

    public User? User { get; set; }
    public UserGroup? UserGroup { get; set; }
}