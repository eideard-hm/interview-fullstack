using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configs
{
    public class InvoiceDetailConfig : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            // define table name
            builder.ToTable("InvoicesDetails");
            // define composed primary key
            builder.HasKey(id => new { id.ProductId, id.InvoiceId});

            // define relationshipt
            builder
                .HasOne(product => product.Product)
                .WithMany(detail => detail.InvoiceDetails);

            builder
                .HasOne(invoice => invoice.Invoice)
                .WithMany(detail => detail.InvoiceDetails);
        }
    }
}
