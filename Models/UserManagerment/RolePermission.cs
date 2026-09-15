namespace QUANLYKHOHANG.API.Models.UserManagement;

public class RolePermission
{
    public Guid RoleId { get; set; }

    public RolesModel Role { get; set; } = null!;

    public Guid PermissionId { get; set; }

    public Permission Permission { get; set; } = null!;
}