using DVLD.Core.Bases;
using DVLD.Data.Requests;
using MediatR;

namespace DVLD.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : UpdateUserRolesRequest, IRequest<Response<string>>
    {
    }
}
