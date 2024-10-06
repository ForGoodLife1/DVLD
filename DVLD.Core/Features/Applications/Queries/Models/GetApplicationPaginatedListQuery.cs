using DVLD.Core.Features.Applications.Queries.Results;
using DVLD.Core.Wrappers;
using DVLD.Data.Enums;
using MediatR;

namespace DVLD.Core.Features.Applications.Queries.Models
{
    public class GetApplicationPaginatedListQuery : IRequest<PaginatedResult<GetApplicationPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ApplicationOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
