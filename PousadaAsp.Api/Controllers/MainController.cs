using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PousadaAsp.Domain.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PousadaAsp.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {

        private readonly INotifier _notifier;
        private bool _hasErrors { get; set; }
        private readonly List<string> _errorsMessage = new List<string>();

        protected MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected ActionResult CustomResponse(ModelStateDictionary model)
        {
            if (!model.IsValid) GetErrors(model);
            
            return CustomResponse();
        }

        protected ActionResult CustomResponse(object obj = null)
        {
            
            if(HasNotification() || obj == null)
            {
                return BadRequest(new {
                    success = false,
                    errors = _notifier.GetNotification()
                });
            }

            return Ok(new
            {
                success = true,
                data = obj
            });
        
        }

    
        private void GetErrors(ModelStateDictionary model)
        {
            var errors = model.Values.SelectMany(x => x.Errors);
            if (errors.Count() > 0)
            {
                foreach(var error in errors)
                {
                    var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                    _notifier.Handle(error.ErrorMessage);
                }
                
            }         

        }

        private bool HasNotification()
        {
            return _notifier.HasNotification();
        }
    }
}
