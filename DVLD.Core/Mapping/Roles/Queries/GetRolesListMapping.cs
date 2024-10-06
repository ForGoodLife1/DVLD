using DVLD.Core.Features.Authorization.Quaries.Results;
using DVLD.Data.Entities.Identity;

namespace DVLD.Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void GetRolesListMapping()
        {
            CreateMap<Role, GetRolesListResult>();
        }
    }
}
