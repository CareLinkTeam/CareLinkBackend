using Application.DTOs;
using Domain;

namespace Application.Interface
{
    public interface IUsersService
    {
        Task<string> SignUpCustomer(CreateUserDto user);
        Task<string> Login(string username, string password);
        Task<Users> UpdateUser(UserDto user);
    }
}
