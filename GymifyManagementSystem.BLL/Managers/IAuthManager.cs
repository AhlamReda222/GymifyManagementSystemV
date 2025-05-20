using GymifyManagementSystem.BLL.Dtos.AuthDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public interface IAuthManager
    {
        Task<string> Register(RegisterDto dto);
        Task<AuthResponseDto> Login(LoginDto dto);
        Task<List<UserReadDto>> GetAllUsers();
        Task<string> CreateRole(RoleAddDto dto);
        Task<string> AssignRoleToUser(AssignRoleDto dto);
        Task<List<RoleReadDto>> GetAllRoles();
    }
}
