using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Interfaces.IService
{
    public interface IService<TEntity> : IDisposable
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetByDocument(string cpf);
        Task<bool> Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
