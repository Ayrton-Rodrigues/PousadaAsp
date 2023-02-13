using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
        private readonly LoginService _loginService;
 

        public LoginController(UserService service, LoginService loginService)
        {
            _userService = service;
            _loginService = loginService;
        }
        [Authorize]
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
        {
            var users = await _userService.GetAll();
            foreach(var user in users)
            {
                user.Password = "";
            }
            
            return CustomResponse(users);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserViewModel register)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _userService.Add(register);

            register.Password = "";
            
            return CustomResponse(register);
        }


        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _userService.GetAll();
            var user = result.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);

            var token = _loginService.Login(user);

            return CustomResponse(token);
        }



    }

            
           
        
}
