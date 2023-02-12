using AutoMapper;
using Projeto.Asp.Api.PousadaAsp.Domain.Entity;
using Projeto.Asp.Api.PousadaAsp.Domain.ViewModels;

namespace Projeto.Asp.Api.Configuration
{
    public class ConfigAutoMapper : Profile
    {
        public ConfigAutoMapper()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
