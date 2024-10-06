using DVLD.Core.Bases;
using DVLD.Data.Responses;
using MediatR;

namespace DVLD.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
