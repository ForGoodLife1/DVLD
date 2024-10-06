/*using AutoMapper;
using DVLD.Core.Bases;
using DVLD.Core.Features.UserCQRS.Queries.Model;
using DVLD.Core.Resources;
using DVLD.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace DVLD.Core.Features.UserCQRS.Queries.Handler
{
    public class UserHandler : ResponseHandler,
                                      IRequestHandler<GetUsersList, Response<List<GetUsersListResponse>>>,
                                      IRequestHandler<GetUserByIDQuery, Response<GetUserByIDResponse>>
    {
        private readonly IUserService _UserService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;


        public UserHandler(IUserService UserService, IMapper _mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _UserService=UserService;
            _mapper=_mapper;
            _stringLocalizer = stringLocalizer;
        }


    }
}
*/