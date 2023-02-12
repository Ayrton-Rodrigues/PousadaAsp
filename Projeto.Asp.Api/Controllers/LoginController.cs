using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto.Asp.Api.PousadaAsp.Data.Context;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces.IService;
using Projeto.Asp.Api.PousadaAsp.Domain.Services;
using Projeto.Asp.Api.PousadaAsp.Domain.ViewModels;
using System;
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

        private readonly IUserService _userService;

        public LoginController(UserService service)
        {
            _userService = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserViewModel register)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _userService.Add(register);

            register.Password = "";
            
            return CustomResponse(register);
        }



    }

            
           
        
}
