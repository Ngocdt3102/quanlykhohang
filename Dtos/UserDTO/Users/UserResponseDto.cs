namespace QUANLYKHOHANG.API.DTOs.UserDTO.Users;

public class UserResponseDto
{
    public Guid Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string? AvatarUrl { get; set; }

    public string Role { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }
}