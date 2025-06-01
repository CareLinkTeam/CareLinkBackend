using Application.ContractRepo;
using Application.DTOs;
using Domain;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository
{
    public class UsersRepository(DataContext dataContext) : IUsersRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<Users> CreateCustomer(CreateUserDto user)
        {
            
            var newUser = new Users()
            {
                Username = user.UserName,
                Password = user.Password,
                Name = user.Name,
                Phone = user.Phone,
                Gender = user.Gender,
                Address = user.Address,
                Age = user.Age
            };

            await _dataContext.Users.AddAsync(newUser);
            await _dataContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<Users> GetUserByUsernamePassword(string username, string password)
        {
            var user = await _dataContext.Users.AsNoTracking()
            .Where(x => x.Username == username && x.Password == password).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            return user;
        }

        public async Task<Users?> GetUserByUsername(string username)
        {
            var user = await _dataContext.Users.AsNoTracking()
                .Where(x => x.Username == username).FirstOrDefaultAsync();
            return user;
        }

    }
}
