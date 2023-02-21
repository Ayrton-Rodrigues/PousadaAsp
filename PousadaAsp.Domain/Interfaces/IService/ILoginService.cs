using PousadaAsp.Domain.ViewModels;
using System;
using System.Threading.Tasks;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Interfaces.IService
{
    public interface ILoginService 
    {
        string Login(LoginViewModel loginViewModel);

    }
}
