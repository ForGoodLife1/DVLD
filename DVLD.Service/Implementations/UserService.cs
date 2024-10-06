using DVLD.Data.Entities;
using DVLD.Data.Enums;
using DVLD.Infrastructure.Abstracts;
using DVLD.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DVLD.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        public async Task<string> AddAsync(User User)
        {
            await _userRepository.AddAsync(User);
            return "Success";
        }

        public async Task<string> DeleteAsync(User User)
        {
            var trans = _userRepository.BeginTransaction();
            try
            {
                await _userRepository.DeleteAsync(User);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.Message);
                return "Falied";
            }
        }

        public async Task<string> EditAsync(User User)
        {
            await _userRepository.UpdateAsync(User);
            return "Success";
        }

        public IQueryable<User> FilterUserPaginatedQuerable(UserOrderingEnum userorderingEnum, string search)
        {
            var querable = _userRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.UserNameAr.Contains(search) || x.PersonId.Equals(search));
            }
            switch (userorderingEnum)
            {
                case UserOrderingEnum.UserId:
                    querable = querable.OrderBy(x => x.UserId);
                    break;
                case UserOrderingEnum.PersonId:
                    querable = querable.OrderBy(x => x.PersonId);
                    break;

                case UserOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.UserNameAr);
                    break;
                case UserOrderingEnum.IsActive:
                    querable = querable.OrderBy(x => x.IsActive);
                    break;
            }

            return querable;
        }

        public async Task<User> GetByIDAsync(int id)
        {
            var User = await _userRepository.GetByIdAsync(id);
            return User;
        }

        public async Task<User> GetUserByIDWithIncludeAsync(int id)
        {
            var User = _userRepository.GetTableNoTracking()
                                         .Include(x => x.Drivers)
                                         .Where(x => x.UserId.Equals(id))
                                         .FirstOrDefault();
            return User;
        }

        public IQueryable<User> GetUsersByOrderIDQuerable(int DID)
        {
            throw new NotImplementedException();
        }

        /* public IQueryable<User> GetUsersByDriverIDQuerable(int DID)
         {
             return _userRepository.GetTableNoTracking().Where(x => x.Drivers.DriverId.Equals(DID)).AsQueryable();
         }*/

        public async Task<List<User>> GetUsersListAsync()
        {
            return await _userRepository.GetTableNoTracking().Include(x => x.Drivers)
                                           .ToListAsync();
        }

        public IQueryable<User> GetUsersQuerable()
        {
            return _userRepository.GetTableNoTracking().Include(x => x.Drivers).AsQueryable();
        }





    }
}
