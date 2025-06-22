using TaxiApp.Core.Application.DTO.Common;

namespace TaxiApp.Core.Application.DTO;

public class UserGroupDto : BasicDto<int>
{
    public ICollection<UserGroupDetailDto>? UserGroupDetails { get; set; }
}