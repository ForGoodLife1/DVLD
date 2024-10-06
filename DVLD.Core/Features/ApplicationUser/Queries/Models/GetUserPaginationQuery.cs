using DVLD.Core.Features.ApplicationUser.Queries.Results;
using DVLD.Core.Wrappers;
using MediatR;

namespace DVLD.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserPaginationReponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
