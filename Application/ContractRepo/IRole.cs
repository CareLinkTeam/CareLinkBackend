using Application.DTOs;
using Domain;

namespace Application.ContractRepo
{
    public interface IRoleRepository
    {
        Task<RoleMapping> GetUserRole(Guid userId);
        Task<bool> MapCustomerRole(Guid userId);
        Task<bool> MapCareTakerRole(Guid userId);
    }
}
