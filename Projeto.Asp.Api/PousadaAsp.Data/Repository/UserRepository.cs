using Microsoft.EntityFrameworkCore;
using Projeto.Asp.Api.PousadaAsp.Data.Context;
using Projeto.Asp.Api.PousadaAsp.Domain.Entity;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Projeto.Asp.Api.PousadaAsp.Data.Repository
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(PousadaAspDbContext db) : base(db) { }
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public async Task<User> GetByDocument(string cpf)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Cpf == cpf);
        }

        
    }

}