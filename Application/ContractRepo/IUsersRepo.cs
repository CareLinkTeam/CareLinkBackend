using Application.DTOs;
using Domain;

namespace Application.ContractRepo
{
    public interface IUsersRepository
    {
        Task<Users> CreateCustomer(CreateUserDto user);
        Task<Users> GetUserByUsernamePassword(string username, string password);
        Task<Users?> GetUserByUsername(string username);
        Task<Users> UpdateUser(UserDto user);
    }
}
