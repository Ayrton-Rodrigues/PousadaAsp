﻿using Microsoft.EntityFrameworkCore;
using Projeto.Asp.Api.PousadaAsp.Data.Context;
using Projeto.Asp.Api.PousadaAsp.Domain.Entity;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Asp.Api.PousadaAsp.Data.Repository
{
    public class BaseRepository<TEntity, K> : IRepository<TEntity, K> where TEntity : BaseEntity, new()
    {
        private readonly PousadaAspDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(PousadaAspDbContext db)
        {
            _context = db;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(K id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task Add(TEntity obj)
        {
            _dbSet.Add(obj);            
            await SaveChanges();
        }

        public virtual async Task Update(TEntity obj)
        {
            _dbSet.Update(obj);
            await SaveChanges();
        }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task Remove(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();

        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
