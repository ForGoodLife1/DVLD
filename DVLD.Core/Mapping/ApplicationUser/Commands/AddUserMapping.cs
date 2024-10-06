using DVLD.Core.Features.ApplicationUser.Commands.Models;
using DVLD.Data.Entities.Identity;

namespace DVLD.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, IdUser>();
        }
    }
}