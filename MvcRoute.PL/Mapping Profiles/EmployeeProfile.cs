using AutoMapper;
using MvcRoute.DAL.Models;
using MvcRoute.PL.Models;

namespace MvcRoute.PL.Mapping_Profiles
{
    public class EmployeeProfile  : Profile
    {
        public EmployeeProfile() {
            CreateMap<EmployeeViewModel, Employee>();
        }
    }
}
