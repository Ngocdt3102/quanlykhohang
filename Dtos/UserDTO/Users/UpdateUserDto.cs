namespace QUANLYKHOHANG.API.DTOs.UserDTO.Users;

public class UpdateUserDto
{
    public string Email { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string? AvatarUrl { get; set; }

    public Guid RoleId { get; set; }
}