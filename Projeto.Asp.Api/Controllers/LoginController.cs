using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Asp.Api.PousadaAsp.Data.Context;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces.IService;
using Projeto.Asp.Api.PousadaAsp.Domain.Services;
using Projeto.Asp.Api.PousadaAsp.Domain.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Asp.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : MainController
    {

        private readonly UserService _userService;
       

        public LoginController(UserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public async Task<ActionResult<UserViewModel>> Register()
        {

            //if (!ModelState.IsValid) return CustomResponse(ModelState);

            var users = await _userService.GetAll();

            return CustomResponse(users);
        }


    }

            
           
        
}
