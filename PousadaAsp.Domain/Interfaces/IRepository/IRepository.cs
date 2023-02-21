using PousadaAsp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PousadaAsp.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetByDocument(string cpf);
        Task Add(TEntity obj);
        Task Update(TEntity obj);
        Task Remove(Guid Id);
        Task<int> SaveChanges();

    }
}
