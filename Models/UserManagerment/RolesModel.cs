using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QUANLYKHOHANG.API.Models.UserManagement;

public class RolesModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

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

    [Required(ErrorMessage = "Thời gian tạo role là bắt buộc.")]
    public DateTime CreatedAt { get; set; }

    // Navigation Property
    public ICollection<UserModel> Users { get; set; }
        = new List<UserModel>();

    // Navigation Property
    public ICollection<RolePermission> RolePermissions { get; set; }
        = new List<RolePermission>();
}