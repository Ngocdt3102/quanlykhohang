using System.ComponentModel.DataAnnotations;

namespace QUANLYKHOHANG.API.Models.UserManagement;

public class RolePermission
{
    [Required(ErrorMessage = "RoleId là bắt buộc.")]
    public int RoleId { get; set; }

    public RolesModel Role { get; set; } = null!;

    [Required(ErrorMessage = "PermissionId là bắt buộc.")]
    public int PermissionId { get; set; }

    public Permission Permission { get; set; } = null!;
}