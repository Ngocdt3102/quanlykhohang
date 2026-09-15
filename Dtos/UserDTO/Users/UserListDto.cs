using System.ComponentModel.DataAnnotations;

namespace QUANLYKHOHANG.API.DTOs.UserDTO.Users;

public class UserListDto
{
    public List<UserResponseDto> Users { get; set; } = new();

    [Range(
        0,
        int.MaxValue,
        ErrorMessage = "TotalCount không được nhỏ hơn 0."
    )]
    public int TotalCount { get; set; }

    [Range(
        1,
        int.MaxValue,
        ErrorMessage = "Page phải lớn hơn hoặc bằng 1."
    )]
    public int Page { get; set; } = 1;

    [Range(
        1,
        100,
        ErrorMessage = "PageSize phải từ 1 đến 100."
    )]
    public int PageSize { get; set; } = 10;

    [Range(
        0,
        int.MaxValue,
        ErrorMessage = "TotalPages không được nhỏ hơn 0."
    )]
    public int TotalPages { get; set; }
}