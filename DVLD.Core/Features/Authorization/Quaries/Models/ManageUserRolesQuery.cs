using DVLD.Core.Bases;
using DVLD.Data.Responses;
using MediatR;

namespace DVLD.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserRolesQuery : IRequest<Response<ManageUserRolesResponse>>
    {
        public int UserId { get; set; }
    }
}
