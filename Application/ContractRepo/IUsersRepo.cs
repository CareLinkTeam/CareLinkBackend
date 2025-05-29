using Application.DTOs;
using Domain;

namespace Application.ContractRepo
{
    public interface IUsersRepository
    {
        Task<Users> CreateUser(CreateUserDto user);
    }
}
