using DVLD.Core.Bases;
using DVLD.Core.Features.Authorization.Quaries.Results;
using MediatR;

namespace DVLD.Core.Features.Authorization.Quaries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResult>>
    {
        public int Id { get; set; }
    }
}
