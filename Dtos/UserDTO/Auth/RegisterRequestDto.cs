using System.ComponentModel.DataAnnotations;

namespace QUANLYKHOHANG.API.DTOs.UserDTO.Auth;

public class RegisterRequestDto
{
    [Required(ErrorMessage = "Username là bắt buộc.")]
    [StringLength(
        50,
        MinimumLength = 3,
        ErrorMessage = "Username phải từ 3 đến 50 ký tự."
    )]
    public string Username { get; set; } = string.Empty;


    [Required(ErrorMessage = "Email là bắt buộc.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    [StringLength(
        100,
        ErrorMessage = "Email không được vượt quá 100 ký tự."
    )]
    public string Email { get; set; } = string.Empty;


    [Required(ErrorMessage = "Password là bắt buộc.")]
    [StringLength(
        20,
        MinimumLength = 8,
        ErrorMessage = "Password phải từ 8 đến 20 ký tự."
    )]
    public string Password { get; set; } = string.Empty;


    [Required(ErrorMessage = "Xác nhận password là bắt buộc.")]
    [Compare(
        "Password",
        ErrorMessage = "Xác nhận password không khớp."
    )]
    public string ConfirmPassword { get; set; } = string.Empty;


    [Required(ErrorMessage = "Họ tên là bắt buộc.")]
    [StringLength(
        100,
        MinimumLength = 2,
        ErrorMessage = "Họ tên phải từ 2 đến 100 ký tự."
    )]
    public string FullName { get; set; } = string.Empty;


    [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
    [StringLength(
        20,
        ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự."
    )]
    public string? PhoneNumber { get; set; }


    [Url(ErrorMessage = "AvatarUrl không đúng định dạng URL.")]
    [StringLength(
        500,
        ErrorMessage = "AvatarUrl không được vượt quá 500 ký tự."
    )]
    public string? AvatarUrl { get; set; }
}