using AutoMapper;

namespace CovidDataPortalApi.Profiles
{
    public class CaseClassProfile : Profile
    {
        public CaseClassProfile()
        {
            CreateMap<Models.Domain.CasesClass, Models.DTO.CasesClass>().ReverseMap();
        }
    }
}
