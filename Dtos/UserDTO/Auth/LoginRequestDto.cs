using System.ComponentModel.DataAnnotations;

namespace QUANLYKHOHANG.API.DTOs.UserDTO.Auth;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Username là bắt buộc.")]
    [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Username phải từ 3 đến 50 ký tự.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password là bắt buộc.")]
    [StringLength(20, MinimumLength = 8,
        ErrorMessage = "Password phải từ 8 đến 20 ký tự.")]
    public string Password { get; set; } = string.Empty;
}