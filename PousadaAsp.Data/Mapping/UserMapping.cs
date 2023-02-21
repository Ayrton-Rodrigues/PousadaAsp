using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PousadaAsp.Domain.Entity;

namespace PousadaAsp.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(80)");
            
            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");              
            
            builder.ToTable("Users");
        }


    }
}
