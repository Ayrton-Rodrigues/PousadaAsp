using Microsoft.EntityFrameworkCore;

namespace Projeto.Asp.Api.PousadaAsp.Data.Context
{
    public class PousadaAspDbContext : DbContext
    {
        public PousadaAspDbContext(DbContextOptions<PousadaAspDbContext> options) : base(options)
        {
        }

        
    }
}
