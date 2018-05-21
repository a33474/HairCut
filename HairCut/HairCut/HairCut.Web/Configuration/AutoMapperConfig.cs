using AutoMapper;
using HairCut.BLL.Entities;
using HairCut.BLL.Entities.Identity;
using HairCut.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace HairCut.Web.Configuration
{
    public static class AutoMapperConfig
    {
        public static IMapperConfigurationExpression AddMapping(this IMapperConfigurationExpression configurationExpression, UserManager<User> userManager)
        {
            Mapper.Initialize(mapper =>
            {
                // Maps
                mapper.CreateMap<Appointment, AppointmentVm>();
                mapper.CreateMap<Client, ClientVm>()
                .ForMember(dest=>dest.Name, y=>y.MapFrom(src=>src.FirstName +" " +src.LastName));
                mapper.CreateMap<User, BaseUserVm>().ForMember(dest => dest.Roles, member => member.MapFrom(src => userManager.GetRolesAsync(src).Result ));
                mapper.CreateMap<Employee, EmployeeVm>()
                 .ForMember(dest => dest.Name, y => y.MapFrom(src => src.FirstName + " " + src.LastName));
            });
            return configurationExpression;
        }
    }
}
