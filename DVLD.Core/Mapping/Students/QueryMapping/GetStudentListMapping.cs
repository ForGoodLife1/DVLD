using DVLD.Core.Features.Applications.Queries.Results;
using DVLD.Data.Entities;

namespace DVLD.Core.Mapping.Applications
{
    public partial class ApplicationProfile
    {
        public void GetApplicationListMapping()
        {
            CreateMap<Application, GetApplicationListResponse>()
               .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Localize(src.Department.DNameAr, src.Department.DNameEn)))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
