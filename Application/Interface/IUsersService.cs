using Application.DTOs;
using Domain;

namespace Application.Interface
{
    public interface IUsersService
    {
        Task<Users> CreateUser(CreateUserDto user);
    }
}
