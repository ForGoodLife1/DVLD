using DVLD.Core.Bases;
using MediatR;

namespace DVLD.Core.Features.Authorization.Commands.Models
{
    public class AddRoleCommand : IRequest<Response<string>>
    {
        public string RoleName { get; set; }
    }
}
