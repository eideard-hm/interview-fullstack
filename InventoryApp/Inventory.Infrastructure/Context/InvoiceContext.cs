using Inventory.Domain.Entities;
using Inventory.Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Context
{
    public class InvoiceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoicesDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=DESKTOP-79UO4HN\SQLEXPRESS;Database=InvoiceDB;User Id=Developer;Password=123456789");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // add own configurations
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new InvoiceConfig());
            builder.ApplyConfiguration(new InvoiceDetailConfig());
        }
    }
}
