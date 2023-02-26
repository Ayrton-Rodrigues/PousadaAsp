using FluentValidation;
using PousadaAsp.Domain.Entity;
using PousadaAsp.Domain.Interfaces.IService;

namespace PousadaAsp.Domain.Services
{
    public class BaseService
    {
        private readonly INotifier _notifier;
        
        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }
        
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            return false;
        }
   
        protected void NotifyError(string message)
        {
            _notifier.Handle(message);
        }

    }

   
}
