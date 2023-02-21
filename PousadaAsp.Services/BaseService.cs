using FluentValidation;
using PousadaAsp.Domain.Entity;
using PousadaAsp.Domain.Interfaces.IService;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Services
{
    public class BaseService
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            return false;
        }
    }
}
