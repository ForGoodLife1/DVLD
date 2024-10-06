using DVLD.Data.Entities;
using DVLD.Data.Enums;

namespace DVLD.Service.Abstracts
{
    public interface IUserService
    {
        public Task<List<User>> GetUsersListAsync();
        // public Task<User> GetUserByIDWithIncludeAsync(int id);
        public Task<User> GetByIDAsync(int id);
        public Task<string> AddAsync(User user);

        public Task<string> EditAsync(User user);
        public Task<string> DeleteAsync(User user);
        public IQueryable<User> GetUsersQuerable();
        public IQueryable<User> GetUsersByOrderIDQuerable(int DID);
        public IQueryable<User> FilterUserPaginatedQuerable(UserOrderingEnum orderingEnum, string search);
    }
}

