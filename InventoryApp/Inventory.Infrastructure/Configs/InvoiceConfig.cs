using Microsoft.EntityFrameworkCore;
using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configs
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            // define primary key
            builder.HasKey(i => i.InvoiceId);

            // define datatype
            builder.Property(i => i.Concept)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(i => i.InvoiceDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Property(i => i.Anulado)
                .HasDefaultValue(false);

            // define relationshipts
            // relation with InvoiceDetail
            builder
                .HasMany(invoice => invoice.InvoiceDetails)
                .WithOne(detail => detail.Invoice);

            // relation with User
            builder
                .HasOne(invoice => invoice.User)
                .WithMany(user => user.Invoices);
        }
    }
}
