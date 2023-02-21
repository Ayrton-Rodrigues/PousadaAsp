using AutoMapper;
using PousadaAsp.Domain.Entity;
using PousadaAsp.Domain.ViewModels;

namespace PousadaAsp.Api.Configuration
{
    public class ConfigAutoMapper : Profile
    {
        public ConfigAutoMapper()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
