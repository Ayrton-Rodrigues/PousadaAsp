using Microsoft.EntityFrameworkCore;
using PousadaAsp.Data.Context;
using PousadaAsp.Domain.Entity;
using PousadaAsp.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace PousadaAsp.Data.Repository
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