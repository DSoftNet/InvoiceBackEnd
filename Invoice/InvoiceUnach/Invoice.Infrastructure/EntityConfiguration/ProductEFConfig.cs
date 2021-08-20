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

            builder.Property(x => x.Desciption)
                .HasMaxLength(255)

            builder.Property(x => x.Code)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasMaxLength()

            builder.Property(x => x.Islva)
                .HasMaxLength()

            builder.Property(x => x.Stock)
                .HasMaxLength()
                .IsRequired();

            builder.Property(x => x.IsExpiration)
                .HasMaxLength()
        
            builder.Property(x => x.Expiration)
                .IsRequired();
            
            builder.Property(x => x.Status)
                .HasMaxLength()

            builder.Property(x => x.CreateAt)
                .IsRequired();

            builder.Property(x => x.UpdateAt)
                .IsRequired();
            
            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasIndex(x => new {x.UserId})
                .IsUnique();


        }
    }
    
}