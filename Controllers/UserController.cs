using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QUANLYKHOHANG.API.DTOs.UserDTO.Users;
using QUANLYKHOHANG.API.Models.UserManagement;

namespace Quanlykhohang.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // =========================================================
        // IN-MEMORY DATA
        // Tạm thời lưu User trong RAM để phục vụ học tập và test API.
        // Sau này sẽ thay bằng Service + Repository + Database.
        // =========================================================

        private static readonly List<UserModel> Users = new()
        {
            new UserModel
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = "HASHED:admin123456",
                FullName = "System Administrator",
                PhoneNumber = "0900000001",
                AvatarUrl = null,
                Status = UserStatus.Active,
                RoleId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                CreatedAt = DateTime.UtcNow.AddYears(-1)
            },

            new UserModel
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Username = "warehouse_manager",
                Email = "manager@example.com",
                PasswordHash = "HASHED:manager123456",
                FullName = "Warehouse Manager",
                PhoneNumber = "0900000002",
                AvatarUrl = null,
                Status = UserStatus.Active,
                RoleId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                CreatedAt = DateTime.UtcNow.AddMonths(-6)
            },

            new UserModel
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Username = "warehouse_staff",
                Email = "staff@example.com",
                PasswordHash = "HASHED:staff123456",
                FullName = "Warehouse Staff",
                PhoneNumber = "0900000003",
                AvatarUrl = null,
                Status = UserStatus.Active,
                RoleId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                CreatedAt = DateTime.UtcNow.AddMonths(-3)
            }
        };


        // =========================================================
        // GET: api/User
        // Lấy danh sách tất cả User
        // =========================================================

        [HttpGet]
        public ActionResult<IEnumerable<UserResponseDto>> GetUsers()
        {
            var list = Users
                .Select(ToResponse)
                .ToList();

            return Ok(list);
        }


        // =========================================================
        // GET: api/User/{id}
        // Lấy thông tin một User theo Id
        // =========================================================

        [HttpGet("{id:guid}")]
        public ActionResult<UserResponseDto> GetUserById(Guid id)
        {
            var user = Users
                .FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy người dùng."
                });
            }

            return Ok(ToResponse(user));
        }


        // =========================================================
        // POST: api/User
        // Tạo User mới
        // =========================================================

        [HttpPost]
        public ActionResult<UserResponseDto> CreateUser(
            [FromBody] CreateUserDto dto)
        {
            // -----------------------------------------------------
            // Kiểm tra Username đã tồn tại chưa
            // -----------------------------------------------------

            var usernameExists = Users.Any(
                x => x.Username.Equals(
                    dto.Username,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            if (usernameExists)
            {
                return Conflict(new
                {
                    message = "Username đã tồn tại."
                });
            }


            // -----------------------------------------------------
            // Kiểm tra Email đã tồn tại chưa
            // -----------------------------------------------------

            var emailExists = Users.Any(
                x => x.Email.Equals(
                    dto.Email,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            if (emailExists)
            {
                return Conflict(new
                {
                    message = "Email đã tồn tại."
                });
            }


            // -----------------------------------------------------
            // Tạo UserModel
            // -----------------------------------------------------

            var model = new UserModel
            {
                Id = Guid.NewGuid(),

                Username = dto.Username,

                Email = dto.Email,

                // TODO:
                // Sau này thay bằng PasswordHasher.
                PasswordHash = "HASHED:" + dto.Password,

                FullName = dto.FullName,

                PhoneNumber = dto.PhoneNumber,

                AvatarUrl = dto.Avatar,

                // User mới mặc định Active.
                Status = UserStatus.Active,

                // Role được lấy từ DTO.
                RoleId = dto.RoleId,

                CreatedAt = DateTime.UtcNow
            };


            // -----------------------------------------------------
            // Thêm User vào danh sách
            // -----------------------------------------------------

            Users.Add(model);


            // -----------------------------------------------------
            // Trả về HTTP 201 Created
            // -----------------------------------------------------

            return CreatedAtAction(
                nameof(GetUserById),
                new { id = model.Id },
                ToResponse(model)
            );
        }


        // =========================================================
        // PUT: api/User/{id}
        // Cập nhật thông tin User
        // =========================================================

        [HttpPut("{id:guid}")]
        public IActionResult UpdateUser(
            Guid id,
            [FromBody] UpdateUserDto dto)
        {
            // -----------------------------------------------------
            // Tìm User
            // -----------------------------------------------------

            var existing = Users
                .FirstOrDefault(x => x.Id == id);

            if (existing == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy người dùng."
                });
            }


            // -----------------------------------------------------
            // Kiểm tra Email có bị User khác sử dụng không
            // -----------------------------------------------------

            var emailExists = Users.Any(
                x =>
                    x.Id != id &&
                    x.Email.Equals(
                        dto.Email,
                        StringComparison.OrdinalIgnoreCase
                    )
            );

            if (emailExists)
            {
                return Conflict(new
                {
                    message = "Email đã được sử dụng bởi người dùng khác."
                });
            }


            // -----------------------------------------------------
            // Cập nhật dữ liệu
            // -----------------------------------------------------

            existing.Email = dto.Email;

            existing.FullName = dto.FullName;

            existing.PhoneNumber = dto.PhoneNumber;

            existing.AvatarUrl = dto.AvatarUrl;

            existing.RoleId = dto.RoleId;

            existing.UpdatedAt = DateTime.UtcNow;


            return NoContent();
        }


        // =========================================================
        // DELETE: api/User/{id}
        // Xóa User
        // =========================================================

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = Users
                .FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy người dùng."
                });
            }


            Users.Remove(user);

            return NoContent();
        }


        // =========================================================
        // HELPER METHOD
        // Chuyển UserModel → UserResponseDto
        //
        // Không trả PasswordHash ra ngoài.
        // =========================================================

        private static UserResponseDto ToResponse(UserModel model)
        {
            return new UserResponseDto
            {
                Id = model.Id,

                Username = model.Username,

                Email = model.Email,

                FullName = model.FullName,

                PhoneNumber = model.PhoneNumber,

                AvatarUrl = model.AvatarUrl,

                Role = model.Role?.Name ?? string.Empty,

                Status = model.Status.ToString(),

                CreatedAt = model.CreatedAt,

                LastLoginAt = model.LastLoginAt
            };
        }
    }
}