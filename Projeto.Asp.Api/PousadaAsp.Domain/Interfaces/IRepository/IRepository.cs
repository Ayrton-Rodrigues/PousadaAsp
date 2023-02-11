﻿using Projeto.Asp.Api.PousadaAsp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Interfaces
{
    public interface IRepository<TEntity, K> : IDisposable where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(K id);
        Task Add(TEntity obj);
        Task Update(TEntity obj);
        Task Remove(Guid Id);
        Task<int> SaveChanges();

    }
}