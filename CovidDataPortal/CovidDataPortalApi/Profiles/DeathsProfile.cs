using AutoMapper;

namespace CovidDataPortalApi.Profiles
{
    public class DeathsProfile:Profile
    {
        public DeathsProfile()
        {
            CreateMap<Models.Domain.Deaths,Models.DTO.Deaths>().ReverseMap(); 
        }
    }
}
