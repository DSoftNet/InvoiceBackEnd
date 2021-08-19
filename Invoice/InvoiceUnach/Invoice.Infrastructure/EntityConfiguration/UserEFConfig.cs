using Invoice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infrastructure.EntityConfiguration
{
    public class UserEFConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.SecondName)
                .HasMaxLength(30);
            
            builder.Property(x => x.FirstLastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.SecondLastName)
                .HasMaxLength(30);
            
            builder.Property(x => x.IdentificationType)
                .HasMaxLength(20)
                .IsRequired();
            
            builder.Property(x => x.Identification)
                .HasMaxLength(30)
                .IsRequired();
            
            builder.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(x => x.Address)
                .HasMaxLength(255);

            builder.Property(x => x.Phone)
                .HasMaxLength(10);
            
            builder.Property(x => x.CellPhone)
                .HasMaxLength(10);
            
            builder.Property(x => x.UserName)
                .HasMaxLength(255);
            
            builder.Property(x => x.Password)
                .HasMaxLength(255);
            
            builder.Property(x => x.Status)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.CreateAt)
                .IsRequired();

            builder.Property(x => x.UpdateAt)
                .IsRequired();

            builder.HasOne<ItemCatalog>()
                .WithMany()
                .HasForeignKey(x => x.IdentificationType)
                .HasPrincipalKey(x => x.Code);
            
            builder.HasOne<ItemCatalog>()
                .WithMany()
                .HasForeignKey(x => x.Status)
                .HasPrincipalKey(x => x.Code);
        }
    }
}