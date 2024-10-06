using DVLD.Core.Features.ApplicationUser.Queries.Results;
using DVLD.Data.Entities.Identity;

namespace DVLD.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<IdUser, GetUserByIdResponse>();
        }
    }
}
