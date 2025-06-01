using Application.DTOs;
using Domain;

namespace Application.Interface
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllRoles();
    }
}
