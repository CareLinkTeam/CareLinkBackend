using Application.ContractRepo;
using Application.DTOs;
using Application.Interface;
using Domain;
using Microsoft.Extensions.Configuration;


namespace Application.Services;

public class RoleService(IConfiguration configuration, IRoleRepository roleRepository) : IRoleService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<List<RoleDto>> GetAllRoles()
    {
        var roles = await _roleRepository.GetAllRoles();
        if (roles == null || roles.Count == 0)
        {
            throw new Exception("No roles found.");
        }
        var roleDtos = roles.Select(role => new RoleDto
        {
            Id = role.Id,
            Role = role.RoleName
        }).ToList();

        return roleDtos;
    }

   
}
