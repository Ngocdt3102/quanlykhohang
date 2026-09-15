namespace QUANLYKHOHANG.API.Models.UserManagement;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }


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


    [Required]
    [StringLength(255)]
    public string PasswordHash { get; set; } = string.Empty;


    [Required(ErrorMessage = "Họ tên là bắt buộc.")]
    [StringLength(
        100,
        MinimumLength = 2,
        ErrorMessage = "Họ tên phải từ 2 đến 100 ký tự."
    )]
    public string FullName { get; set; } = string.Empty;


    [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
    [StringLength(20)]
    public string? PhoneNumber { get; set; }


    [Url(ErrorMessage = "AvatarUrl không đúng định dạng URL.")]
    [StringLength(500)]
    public string? AvatarUrl { get; set; }


    public UserStatus Status { get; set; } = UserStatus.Active;


    public int RoleId { get; set; }

    public RolesModel Role { get; set; } = null!;


    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }
}


public enum UserStatus
{
    Active = 1,
    Inactive = 2,
    Locked = 3,
    Deleted = 4
}