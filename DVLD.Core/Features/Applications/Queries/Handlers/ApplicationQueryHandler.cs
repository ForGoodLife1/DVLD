using AutoMapper;
using DVLD.Core.Bases;
using DVLD.Core.Features.Applications.Queries.Models;
using DVLD.Core.Features.Applications.Queries.Results;
using DVLD.Core.Resources;
using DVLD.Core.Wrappers;
using DVLD.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace DVLD.Core.Features.Applications.Queries.Handlers
{
    public class ApplicationQueryHandler : ResponseHandler,
                                       IRequestHandler<GetApplicationListQuery, Response<List<GetApplicationListResponse>>>,
                                       IRequestHandler<GetApplicationByIDQuery, Response<GetSingleApplicationResponse>>,
                                       IRequestHandler<GetApplicationPaginatedListQuery, PaginatedResult<GetApplicationPaginatedListResponse>>
    {

        #region Fields
        private readonly IApplicationService _ApplicationService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ApplicationQueryHandler(IApplicationService ApplicationService,
                                   IMapper mapper,
                                   IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _ApplicationService=ApplicationService;
            _mapper=mapper;
            _stringLocalizer=stringLocalizer;
        }
        #endregion


        #region Handle Functions

        public async Task<Response<List<GetApplicationListResponse>>> Handle(GetApplicationListQuery request, CancellationToken cancellationToken)
        {
            var ApplicationList = await _ApplicationService.GetApplicationsListAsync();
            var ApplicationListMapper = _mapper.Map<List<GetApplicationListResponse>>(ApplicationList);
            var result = Success(ApplicationListMapper);
            result.Meta=new { Count = ApplicationListMapper.Count() };
            return result;
        }

        public async Task<Response<GetSingleApplicationResponse>> Handle(GetApplicationByIDQuery request, CancellationToken cancellationToken)
        {
            var Application = await _ApplicationService.GetApplicationByIDWithIncludeAsync(request.Id);
            if (Application==null) return NotFound<GetSingleApplicationResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetSingleApplicationResponse>(Application);
            return Success(result);
        }

        public async Task<PaginatedResult<GetApplicationPaginatedListResponse>> Handle(GetApplicationPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Application, GetApplicationPaginatedListResponse>> expression = e => new GetApplicationPaginatedListResponse(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr, e.Department.DNameEn));
            var FilterQuery = _ApplicationService.FilterApplicationPaginatedQuerable(request.OrderBy, request.Search);
            var PaginatedList = await _mapper.ProjectTo<GetApplicationPaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedList.Meta=new { Count = PaginatedList.Data.Count() };
            return PaginatedList;
        }

        #endregion
    }
}
