using DVLD.Core.Bases;
using DVLD.Core.Features.Applications.Queries.Results;
using MediatR;

namespace DVLD.Core.Features.Applications.Queries.Models
{
    public class GetApplicationListQuery : IRequest<Response<List<GetApplicationListResponse>>>
    {
    }
}
