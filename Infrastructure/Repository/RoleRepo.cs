using Application.ContractRepo;
using Application.DTOs;
using Domain;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository
{
    public class RoleRepository(DataContext dataContext) : IRoleRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<RoleMapping> GetUserRole(Guid userId)
        {
            // check if the user is exist
            var user = await _dataContext.RoleMapping.AsNoTracking()
                .Where(x => x.UserId == userId).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("User Not found");
            }

            return user;
        }

        public async Task<bool> MapCustomerRole(Guid userId)
        {

            var roleMapping = new RoleMapping()
            {
                UserId = userId,
                RoleId = 1
            };

            await _dataContext.RoleMapping.AddAsync(roleMapping);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MapCareTakerRole(Guid userId)
        {

            var roleMapping = new RoleMapping()
            {
                UserId = userId,
                RoleId = 2
            };

            await _dataContext.RoleMapping.AddAsync(roleMapping);
            await _dataContext.SaveChangesAsync();
            return true;
        }

    }
}
