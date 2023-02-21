using Microsoft.EntityFrameworkCore;
using PousadaAsp.Data.Mapping;
using PousadaAsp.Domain.Entity;


namespace PousadaAsp.Data.Context
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
