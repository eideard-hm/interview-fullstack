using Microsoft.EntityFrameworkCore;
using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // define primary key
            builder.HasKey(p => p.ProductId);

            //define datatypes
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("VARCHAR(2000)");

            // define relationship between tables
            builder
                .HasMany(p => p.InvoiceDetails)
                .WithOne(detail => detail.Product);
        }
    }
}
