using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Asp.Api.PousadaAsp.Data.Context;
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


        public LoginController()
        {
   

        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Register()
        {
 
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var t = await Task.FromResult(1);

            return CustomResponse(t);
        }


    }

            
           
        
}
