using Microsoft.EntityFrameworkCore;
using Projeto.Asp.Api.PousadaAsp.Data.Mapping;
using Projeto.Asp.Api.PousadaAsp.Domain.Entity;

namespace Projeto.Asp.Api.PousadaAsp.Data.Context
{
    public class PousadaAspDbContext : DbContext
    {
        public PousadaAspDbContext(DbContextOptions<PousadaAspDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PousadaAspDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMapping());
        }

    }
}
