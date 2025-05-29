using Application.ContractRepo;
using Application.DTOs;
using Application.Interface;
using Domain;
using Microsoft.Extensions.Configuration;


namespace Application.Services
{
    public class UsersService(IUsersRepository userRepository, IConfiguration configuration) : IUsersService
    {
        private readonly IUsersRepository _usersRepository = userRepository;

        private readonly IConfiguration _configuration = configuration;

        public async Task<Users> CreateUser(CreateUserDto user)
        {  
            var createuser = await _usersRepository.CreateUser(user);
            return createuser;
        }
       
    }
}
