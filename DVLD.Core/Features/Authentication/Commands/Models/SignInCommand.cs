
using DVLD.Core.Bases;
using DVLD.Data.Responses;
using MediatR;

namespace DVLD.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
