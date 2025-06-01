using Application.DTOs;
using Domain;

namespace Application.Interface
{
    public interface IUsersService
    {
        Task<string> SignUpCustomer(CreateUserDto user);
        Task<string> Login(string username, string password);
    }
}
