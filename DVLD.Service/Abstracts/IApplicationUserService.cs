using DVLD.Data.Entities.Identity;

namespace DVLD.Service.Abstracts
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(IdUser idUser, string password);
    }
}

