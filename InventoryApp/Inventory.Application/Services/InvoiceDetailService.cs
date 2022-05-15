using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;

namespace Inventory.Application.Services
{
    public class InvoiceDetailService : IInvoiceDetailService<InvoiceDetail, int>
    {
        private readonly IInvoiceDetailRepository<InvoiceDetail, int> _repository;
        public InvoiceDetailService(IInvoiceDetailRepository<InvoiceDetail, int> repository)
        {
            _repository = repository;
        }
        public InvoiceDetail Add(InvoiceDetail invoiceDetail)
        {
            if(invoiceDetail == null)
            {
                throw new ArgumentNullException("El 'Detalle de Factura' es requerido!");
            }
            var invoiceDetailAdd = _repository.Add(invoiceDetail);
            return invoiceDetailAdd;
        }

        public List<InvoiceDetail> GetAll()
        {
            return _repository.GetAll();
        }

        public InvoiceDetail GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
