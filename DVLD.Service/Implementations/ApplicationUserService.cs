using DVLD.Data.Entities.Identity;
using DVLD.Infrastructure.DvldDbContext;
using DVLD.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Service.Implementations
{
    public class ApplicationUserService : IApplicationUserService
    {
        #region Fields
        private readonly UserManager<IdUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailsService _emailsService;
        private readonly DvldContext _applicationDBContext;
        private readonly IUrlHelper _urlHelper;
        #endregion
        #region Constructors
        public ApplicationUserService(UserManager<IdUser> userManager,
                                      IHttpContextAccessor httpContextAccessor,
                                      IEmailsService emailsService,
                                      DvldContext applicationDBContext,
                                      IUrlHelper urlHelper)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _emailsService = emailsService;
            _applicationDBContext = applicationDBContext;
            _urlHelper = urlHelper;
        }
        #endregion
        #region Handle Functions
        public async Task<string> AddUserAsync(IdUser idUser, string password)
        {
            var trans = await _applicationDBContext.Database.BeginTransactionAsync();
            try
            {
                //if Email is Exist
                var existUser = await _userManager.FindByEmailAsync(idUser.Email);
                //email is Exist
                if (existUser != null) return "EmailIsExist";

                //if username is Exist
                var userByUserName = await _userManager.FindByNameAsync(idUser.UserName);
                //username is Exist
                if (userByUserName != null) return "UserNameIsExist";
                //Create
                var createResult = await _userManager.CreateAsync(idUser, password);
                //Failed
                if (!createResult.Succeeded)
                    return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());

                await _userManager.AddToRoleAsync(idUser, "User");

                //Send Confirm Email
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(idUser);
                var resquestAccessor = _httpContextAccessor.HttpContext.Request;
                var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = idUser.Id, code = code });
                var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";
                //$"/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
                //message or body
                await _emailsService.SendEmail(idUser.Email, message, "ConFirm Email");

                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }

        }
        #endregion
    }
}
