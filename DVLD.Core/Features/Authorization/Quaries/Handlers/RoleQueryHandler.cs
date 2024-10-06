using AutoMapper;
using DVLD.Core.Bases;
using DVLD.Core.Features.Authorization.Quaries.Models;
using DVLD.Core.Features.Authorization.Quaries.Results;
using DVLD.Core.Resources;
using DVLD.Data.Entities.Identity;
using DVLD.Data.Responses;
using DVLD.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace DVLD.Core.Features.Authorization.Quaries.Handlers
{
    public class RoleQueryHandler : ResponseHandler,
       IRequestHandler<GetRolesListQuery, Response<List<GetRolesListResult>>>,
       IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResult>>,
       IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResponse>>
    {
        #region Fields
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<IdUser> _userManager;
        #endregion
        #region Constructors
        public RoleQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                IAuthorizationService authorizationService,
                                IMapper mapper,
                                UserManager<IdUser> userManager) : base(stringLocalizer)
        {
            _authorizationService=authorizationService;
            _mapper=mapper;
            _stringLocalizer=stringLocalizer;
            _userManager=userManager;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<List<GetRolesListResult>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRolesList();
            var result = _mapper.Map<List<GetRolesListResult>>(roles);
            return Success(result);
        }

        public async Task<Response<GetRoleByIdResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleById(request.Id);
            if (role==null) return NotFound<GetRoleByIdResult>(_stringLocalizer[SharedResourcesKeys.RoleNotExist]);
            var result = _mapper.Map<GetRoleByIdResult>(role);
            return Success(result);
        }

        public async Task<Response<ManageUserRolesResponse>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user==null) return NotFound<ManageUserRolesResponse>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
            var result = await _authorizationService.ManageUserRolesData(user);
            return Success(result);
        }
        #endregion
    }
}
