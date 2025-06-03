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

        public async Task<Users> UpdateUser(UserDto user)
        {
            var existUser = await _dataContext.Users
            .Where(x => x.Username == user.UserName).FirstOrDefaultAsync();

            if (existUser == null)
            {
                throw new Exception("User Not Found");
            }

            if (!string.IsNullOrEmpty(user.Name))
            {
                existUser.Name = user.Name;
            }
            if (!string.IsNullOrEmpty(user.Phone))
            {
                existUser.Phone = user.Phone;
            }
            if (!string.IsNullOrEmpty(user.Gender))
            {
                existUser.Gender = user.Gender;
            }
            if (!string.IsNullOrEmpty(user.Address))
            {
                existUser.Address = user.Address;
            }
            if (user.Age.HasValue)
            {
                existUser.Age = user.Age;
            }
            if (!string.IsNullOrEmpty(user.Image))
            {
                existUser.Image = user.Image;
            }

            _dataContext.Users.Update(existUser);
            await _dataContext.SaveChangesAsync();
            return existUser;
        }
        
        public async Task<string> DeleteUser(string username)
        {
            var user = await _dataContext.Users.AsNoTracking()
                .Where(x => x.Username == username).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            // Remove related RoleMapping entries
            var roleMappings = await _dataContext.RoleMapping
                .Where(x => x.UserId == user.Id).ToListAsync();
            _dataContext.RoleMapping.RemoveRange(roleMappings);

            // Remove the user
            var userToDelete = await _dataContext.Users
                .Where(x => x.Username == username).FirstOrDefaultAsync();
            if (userToDelete != null)
            {
                _dataContext.Users.Remove(userToDelete);
                await _dataContext.SaveChangesAsync();
            }

            var response = $"User {username} deleted successfully.";
    
            return response;
        }


    }
}
