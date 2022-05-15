using Microsoft.EntityFrameworkCore;
using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // define primary key
            builder.HasKey(u => u.UserId);

            // define datatypes
            builder.Property(u => u.FullName)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(u => u.DocumentType)
                .IsRequired()
                .HasColumnType("VARCHAR(3)");

            builder.Property(u => u.DocumentNumber)
                .IsRequired()
                .HasColumnType("VARCHAR(11)");

            builder.Property(u => u.Age)
                .IsRequired()
                .HasColumnType("TINYINT");

            // define relationshipts
            builder
                .HasMany(user => user.Invoices)
                .WithOne(invoice => invoice.User);
        }
    }
}
