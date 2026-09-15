namespace QUANLYKHOHANG.API.DTOs.UserDTO.Auth;
using QUANLYKHOHANG.API.DTOs.UserDTO.Users;

public class LoginResponseDto
{
    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }

    public UserResponseDto User { get; set; } = null!;
}