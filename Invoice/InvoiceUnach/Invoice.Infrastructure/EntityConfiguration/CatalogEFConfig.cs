using Invoice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infrastructure.EntityConfiguration
{
    public class CatalogEFConfig : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.ToTable(nameof(Catalog));

            builder.HasKey(t => t.Id);
            
            builder.HasIndex(e => new { e.Code }).IsUnique();

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Code)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.Value)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Status)
                .IsRequired();
        }
    }
}