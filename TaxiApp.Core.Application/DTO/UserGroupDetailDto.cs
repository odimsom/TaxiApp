namespace TaxiApp.Core.Application.DTO;

public class UserGroupDetailDto
{
    public required int UserId { get; set; }
    public required int UserGroupId { get; set; }

    public UserDto? User { get; set; }
    public UserGroupDto? UserGroup { get; set; }
}