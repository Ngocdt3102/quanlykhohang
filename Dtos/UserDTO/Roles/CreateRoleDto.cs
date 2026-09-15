using System.ComponentModel.DataAnnotations;

namespace QUANLYKHOHANG.API.DTOs.UserDTO.Roles;

public class CreateRoleDto
{
    [Required(ErrorMessage = "Tên role là bắt buộc.")]
    [StringLength(
        50,
        MinimumLength = 2,
        ErrorMessage = "Tên role phải từ 2 đến 50 ký tự."
    )]
    public string Name { get; set; } = string.Empty;


    [StringLength(
        255,
        ErrorMessage = "Mô tả role không được vượt quá 255 ký tự."
    )]
    public string? Description { get; set; }


    public List<int> PermissionIds { get; set; } = new();
}