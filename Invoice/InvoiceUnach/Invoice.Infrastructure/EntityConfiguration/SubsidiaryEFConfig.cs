using Invoice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infrastructure.EntityConfiguration
{
    public class SubsidiaryEFConfig  : IEntityTypeConfiguration<Subsidiary>
    {
        public void Configure(EntityTypeBuilder<Subsidiary> builder)
        {
            builder.ToTable(nameof(Subsidiary));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Address)
                .HasMaxLength(30);
            
            builder.Property(x => x.Phone1)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Phone2)
                .HasMaxLength(10);
           
            builder.Property(x => x.CreateAt)
                .IsRequired();

            builder.Property(x => x.UpdateAt)
                .IsRequired();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id); 
        }
    }
}