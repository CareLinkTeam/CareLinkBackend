using Application.ContractRepo;
using Application.DTOs;
using Application.Interface;
using Application.Utils;
using BCrypt.Net;
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

        public async Task<string> SignUpCustomer(CreateUserDto user)
        {

            var existingUser = await _usersRepository.GetUserByUsername(user.UserName);
            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }
            //hashed password
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt(12));

            var createdUser = await _usersRepository.CreateCustomer(user);
            var roleMapping = await _roleRepository.MapCustomerRole(createdUser.Id);
            if (!roleMapping)
            {
                throw new Exception("Failed to map customer role.");
            }

            var jwtToken = _jwtTokenService.GenerateToken(createdUser.Id, user.Name, IdentityData.CustomerRole);

            return jwtToken;
        }
        public async Task<string> Login(string username, string password)
        {
            var existingUser = await _usersRepository.GetUserByUsername(username);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, existingUser.Password);
            if (!isValidPassword)
            {
                throw new Exception("Invalid password");
            }

            //Get User Role
            var userRole = await _roleRepository.GetUserRole(existingUser.Id);
            return _jwtTokenService.GenerateToken(existingUser.Id, existingUser.Name, IdentityData.CustomerRole);

        }

        public async Task<Users> UpdateUser(UserDto user)
        {
            var userData = await _usersRepository.GetUserByUsername(user.UserName);
            var idUser = _jwtTokenService.GetUserIdFromToken();

            if (userData == null)
            {
                throw new Exception("User not found.");
            }
            if (userData.Id != Guid.Parse(idUser))
            {
                throw new Exception("User not unauthorized.");
            }

            var updatedUser = await _usersRepository.UpdateUser(user);
            
            return updatedUser;
        }

        public async Task<Users> GetUserByUsername(string username)
        {
            var user = await _usersRepository.GetUserByUsername(username);
            var idUser = _jwtTokenService.GetUserIdFromToken();

            if (user == null)
            {
                throw new Exception("User not found.");
            }
            if (user.Id != Guid.Parse(idUser))
            {
                throw new Exception("User not unauthorized.");
            }

            return user;
        }
        
        public async Task<string> DeleteUser (string username)
        {
            var user = await _usersRepository.GetUserByUsername(username);
            var idUser = _jwtTokenService.GetUserIdFromToken();

            if (user == null)
            {
                throw new Exception("User not found.");
            }
            if (user.Id != Guid.Parse(idUser))
            {
                throw new Exception("User not unauthorized.");
            }

            var deletedUser = await _usersRepository.DeleteUser(username);

            return deletedUser;
        }


    }
}