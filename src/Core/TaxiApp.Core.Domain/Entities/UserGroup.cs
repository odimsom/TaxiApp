using TaxiApp.Core.Domain.Common;

namespace TaxiApp.Core.Domain.Entities;

public class UserGroup : BasicEntity<int>
{
    public ICollection<UserGroupDetail>? UserGroupDetails { get; set; }
}
