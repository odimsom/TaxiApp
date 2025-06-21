namespace TaxiApp.Core.Application.DTO;

public class UserGroupDto
{
    public ICollection<UserGroupDetailDto>? UserGroupDetails { get; set; }
}