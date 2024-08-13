using AutoMapper;
using MvcRoute.DAL.Models;
using MvcRoute.PL.Models;

namespace MvcRoute.PL.Mapping_Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {  
            CreateMap<RegisterViewModel, ApplicationUser>();

        }
    }
}
