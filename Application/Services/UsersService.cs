using Application.ContractRepo;
using Application.DTOs;
using Application.Interface;
using Application.Utils;
using Domain;
using Microsoft.Extensions.Configuration;



namespace Application.Services
{
    public class UsersService(
        IUsersRepository userRepository,
        IConfiguration configuration,
        IRoleRepository roleRepository,
        JwtTokenService jwtTokenService) : IUsersService
    {
        private readonly IUsersRepository _usersRepository = userRepository;
        private readonly IConfiguration _configuration = configuration;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly JwtTokenService _jwtTokenService = jwtTokenService;

        public async Task<Users> CreateCustomer(CreateUserDto user)
        {
            var createuser = await _usersRepository.CreateCustomer(user);
            return createuser;
        }

        public async Task<string> SignUpCustomer(CreateUserDto user)
        {
            var createdUser = await _usersRepository.CreateCustomer(user);
            var roleMapping = await _roleRepository.MapCustomerRole(createdUser.Id);
            if (!roleMapping)
            {
                throw new Exception("Failed to map customer role.");
            }
            var jwtToken = _jwtTokenService.GenerateToken(createdUser.Id, createdUser.Name ?? "Unknown", IdentityData.CustomerRole);

            return jwtToken;
        }
        public async Task<string> Login(string username, string password)
        {
            var user = await _usersRepository.GetUserByUsernamePassword(username, password);
            throw new NotImplementedException("Login functionality is not implemented yet.");
        }

    }
}