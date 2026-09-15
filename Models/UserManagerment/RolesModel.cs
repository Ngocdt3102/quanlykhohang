namespace QUANLYKHOHANG.API.Models.UserManagement;

public class RolesModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<UserModel> Users { get; set; }
        = new List<UserModel>();

    public ICollection<RolePermission> RolePermissions { get; set; }
        = new List<RolePermission>();
}