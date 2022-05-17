using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;
using Inventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository<InvoiceDetail, int>
    {
        private readonly InvoiceContext _db;
        public InvoiceDetailRepository(InvoiceContext db)
        {
            _db = db;
        }

        public InvoiceDetail Add(InvoiceDetail invoiceDetail)
        {
            _db.InvoicesDetails.Add(invoiceDetail);
            return invoiceDetail;
        }

        public List<InvoiceDetail> GetAll()
        {
            return _db.InvoicesDetails
                                      .Include(detail => detail.Invoice)
                                      .Include(detail => detail.Product)
                                      .AsNoTracking()
                                      .ToList();
        }

        public InvoiceDetail GetById(int id)
        {
            return _db.InvoicesDetails
                                      .AsNoTracking()
                                      .Include(detail => detail.Invoice)
                                      .Include(detail => detail.Product)
                                      .FirstOrDefault(detail => detail.InvoiceId == id && detail.ProductId == id);
        }

        public void SaveAllChanges()
        {
            _db.SaveChanges();
        }
    }
}
