using System.ComponentModel.DataAnnotations;

namespace QUANLYKHOHANG.API.DTOs.UserDTO.Users;

public class UpdateUserDto
{
    [Required(ErrorMessage = "Email là bắt buộc.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    [StringLength(
        100,
        ErrorMessage = "Email không được vượt quá 100 ký tự."
    )]
    public string Email { get; set; } = string.Empty;


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


    [Range(
        1,
        int.MaxValue,
        ErrorMessage = "RoleId phải lớn hơn 0."
    )]
    public int RoleId { get; set; }
}