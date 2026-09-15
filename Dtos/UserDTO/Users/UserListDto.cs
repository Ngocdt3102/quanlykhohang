namespace QUANLYKHOHANG.API.DTOs.UserDTO.Users;

public class UserListDto
{
    public List<UserResponseDto> Users { get; set; }
        = new();

    public int TotalCount { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalPages { get; set; }
}