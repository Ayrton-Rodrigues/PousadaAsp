using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PousadaAsp.Domain.Interfaces.IService
{
    public interface IService<TEntity> : IDisposable
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<bool> Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
