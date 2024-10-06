using DVLD.Data.Entities.Identity;
using DVLD.Data.Responses;
using System.IdentityModel.Tokens.Jwt;
namespace DVLD.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResponse> GetJWTToken(IdUser idUser);
        public JwtSecurityToken ReadJWTToken(string accessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken);
        public Task<JwtAuthResponse> GetRefreshToken(IdUser idUser, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
        public Task<string> ValidateToken(string AccessToken);
        public Task<string> ConfirmEmail(int? userId, string? code);
        public Task<string> SendResetPasswordCode(string Email);
        public Task<string> ConfirmResetPassword(string Code, string Email);
        public Task<string> ResetPassword(string Email, string Password);
    }
}
