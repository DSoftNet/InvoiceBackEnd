using Invoice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infrastructure.EntityConfiguration
{
    public class ProductEFConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(255);

            builder.Property(x => x.Code)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasMaxLength(100);

            builder.Property(x => x.IsIva)
                .HasMaxLength(100);

            builder.Property(x => x.Stock)

                .IsRequired();

            builder.Property(x => x.IsExpiration)
                
            builder.Property(x => x.ExpirationAt)
                .IsRequired();

            builder.Property(x => x.Status);
                
            builder.Property(x => x.CreateAt)
                .IsRequired();

            builder.Property(x => x.UpdateAt)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();
        }
    }
    
}