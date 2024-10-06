using DVLD.Core.Bases;
using DVLD.Data.Responses;
using MediatR;

namespace DVLD.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResponse>>
    {
        public int UserId { get; set; }
    }
}
