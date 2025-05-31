using Application.DTOs;
using Domain;

namespace Application.Interface
{
    public interface IUsersService
    {
        Task<Users> CreateCustomer(CreateUserDto user);
        Task<string> SignUpCustomer(CreateUserDto user);
        Task<string> Login(string username, string password);
    }
}
