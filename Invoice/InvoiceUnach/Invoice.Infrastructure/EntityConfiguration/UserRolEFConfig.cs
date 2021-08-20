using Invoice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infrastructure.EntityConfiguration
{
    public class UserRolEFConfig : IEntityTypeConfiguration<UserRol>
    {
        public void Configure(EntityTypeBuilder<UserRol> builder)
        {
            builder.ToTable(nameof(UserRol));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.RolName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasOne<ItemCatalog>()
                .WithMany()
                .HasForeignKey(x => x.RolName)
                .HasPrincipalKey(x => x.Code)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new {x.UserId})
                .IsUnique();
        }
    }
}