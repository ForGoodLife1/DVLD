using DVLD.Core.Bases;
using DVLD.Core.Features.Applications.Queries.Results;
using MediatR;

namespace DVLD.Core.Features.Applications.Queries.Models
{
    public class GetApplicationByIDQuery : IRequest<Response<GetSingleApplicationResponse>>
    {
        public int Id { get; set; }
        public GetApplicationByIDQuery(int id)
        {
            Id=id;
        }
    }
}
