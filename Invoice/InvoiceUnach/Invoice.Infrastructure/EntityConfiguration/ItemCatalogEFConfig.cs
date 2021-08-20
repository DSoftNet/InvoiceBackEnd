using Invoice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infrastructure.EntityConfiguration
{
    public class ItemCatalogEFConfig : IEntityTypeConfiguration<ItemCatalog>
    {
        public void Configure(EntityTypeBuilder<ItemCatalog> builder)
        {
            builder.ToTable(nameof(ItemCatalog));

            builder.HasKey(t => t.Id);

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

            builder.Property(t => t.CodeCatalog)
                .HasMaxLength(20)
                .IsRequired();
            
            builder.HasIndex(t => new {t.Code})
                .IsUnique();
            
            builder.HasOne<Catalog>()
                .WithMany()
                .HasForeignKey(t => t.CodeCatalog)
                .HasPrincipalKey(t=>t.Code);
        }
    }
}