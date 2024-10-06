using DVLD.Data.Entities.Identity;

namespace DVLD.Service.AuthServices.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<IdUser> GetUserAsync();
        public int GetUserId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
