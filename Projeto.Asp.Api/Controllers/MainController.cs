using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Asp.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        
        private bool _haveErrors { get; set; }
        private List<string> _errorsMessage = new List<string>();

        protected ActionResult CustomResponse(ModelStateDictionary model)
        {
            if (!model.IsValid) GetErrors(model);
            
            return CustomResponse();
        }

        protected ActionResult CustomResponse(object obj = null)
        {
            
            if(_haveErrors)
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
                foreach(var erro in errors)
                {
                    var errorMessage = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    _errorsMessage.Add(erro.ErrorMessage);
                }
                return _haveErrors = true;
            }

            return _haveErrors = false;

        }
    }
}
