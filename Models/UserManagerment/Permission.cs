using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QUANLYKHOHANG.API.Models.UserManagement;

public class Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên permission là bắt buộc.")]
    [StringLength(
        100,
        MinimumLength = 2,
        ErrorMessage = "Tên permission phải từ 2 đến 100 ký tự."
    )]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Resource là bắt buộc.")]
    [StringLength(
        50,
        MinimumLength = 2,
        ErrorMessage = "Resource phải từ 2 đến 50 ký tự."
    )]
    public string Resource { get; set; } = string.Empty;

    [Required(ErrorMessage = "Action là bắt buộc.")]
    [StringLength(
        50,
        MinimumLength = 2,
        ErrorMessage = "Action phải từ 2 đến 50 ký tự."
    )]
    public string Action { get; set; } = string.Empty;

    [StringLength(
        255,
        ErrorMessage = "Description không được vượt quá 255 ký tự."
    )]
    public string? Description { get; set; }

    // Navigation Property
    public ICollection<RolePermission> RolePermissions { get; set; }
        = new List<RolePermission>();
}