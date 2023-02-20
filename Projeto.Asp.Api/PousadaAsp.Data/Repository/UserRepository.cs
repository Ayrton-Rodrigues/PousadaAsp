using Microsoft.EntityFrameworkCore;
using Projeto.Asp.Api.PousadaAsp.Data.Context;
using Projeto.Asp.Api.PousadaAsp.Domain.Entity;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Projeto.Asp.Api.PousadaAsp.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PousadaAspDbContext db) : base(db) { }
        public override async Task<User> GetByDocument(string cpf)

        {
            return await _context.User.FirstOrDefaultAsync(u => u.Cpf == cpf);
        }

        
    }

}