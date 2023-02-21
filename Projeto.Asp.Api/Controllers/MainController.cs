using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Asp.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
   

        private bool _hasErrors { get; set; }
        private readonly List<string> _errorsMessage = new List<string>();

        protected ActionResult CustomResponse(ModelStateDictionary model)
        {
            if (!model.IsValid) GetErrors(model);
            
            return CustomResponse();
        }

        protected ActionResult CustomResponse(object obj = null)
        {
            
            if(_hasErrors || obj == null)
            {
                return BadRequest(new {
                    success = false,
                    errors = _errorsMessage
                });
            }

            return Ok(new
            {
                success = true,
                data = obj
            });
        
        }

    
        private bool GetErrors(ModelStateDictionary model)
        {
            var errors = model.Values.SelectMany(x => x.Errors);
            if (errors.Count() > 0)
            {
                foreach(var error in errors)
                {
                    var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                    _errorsMessage.Add(error.ErrorMessage);
                }
                return _hasErrors = true;
            }

            return _hasErrors = false;

        }
    }
}
