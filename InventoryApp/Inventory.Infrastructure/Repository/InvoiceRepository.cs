using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;
using Inventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class InvoiceRepository : IInvoiceRepository<Invoice, int>
    {
        private readonly InvoiceContext _db;
        public InvoiceRepository(InvoiceContext invoiceRepository)
        {
            _db = invoiceRepository;
        }
        public Invoice Add(Invoice product)
        {
            _db.Invoices.Add(product);
            return product;
        }

        public void Anular(int id)
        {
            var prodAnular = _db.Invoices.AsNoTracking().FirstOrDefault(i => i.InvoiceId == id);
            if(prodAnular == null)
            {
                throw new NullReferenceException("Esta intentando eliminar una factura que no existe.");
            }
            prodAnular.Anulado = true;
            _db.Entry(prodAnular).State = EntityState.Modified;
        }

        public List<Invoice> GetAll()
        {
            return _db.Invoices
                               .Include(i => i.InvoiceDetails)
                               .ThenInclude(id => id.Product)
                               .AsNoTracking()
                               .ToList();
        }

        public Invoice GetById(int id)
        {
            return _db.Invoices.AsNoTracking().FirstOrDefault(i => i.InvoiceId == id);
        }

        public void SaveAllChanges()
        {
            _db.SaveChanges();
        }
    }
}
