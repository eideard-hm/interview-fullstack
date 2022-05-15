using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;

namespace Inventory.Application.Services
{
    public class InvoiceService : IInvoiceService<Invoice, int>
    {
        private readonly IInvoiceRepository<Invoice, int> _invoiceRepository;
        private readonly IBaseRepository<Product, int> _productRepository;
        private readonly IInvoiceDetailRepository<InvoiceDetail, int> _invoiceDetailRepository;
        public InvoiceService(IInvoiceRepository<Invoice, int> invoiceRepository,
                              IBaseRepository<Product, int> productRepository,
                              IInvoiceDetailRepository<InvoiceDetail, int> invoiceDetailRepository)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
            _invoiceRepository = invoiceRepository;
            _productRepository = productRepository;
        }

        public Invoice Add(Invoice invoice)
        {
            if(invoice == null)
            {
                throw new ArgumentNullException("La 'Factura' es requerida!");
            }
            var newInvoice = _invoiceRepository.Add(invoice);

            newInvoice.InvoiceDetails.ForEach(detail =>
            {
                var produSelected = _productRepository.GetById(detail.ProductId);
                if (produSelected == null)
                {
                    throw new NullReferenceException("Esta intentando vender un producto que no existe 😡😡");
                }

                detail.UnitCost = produSelected.Cost;
                detail.UnitPrice = produSelected.Price;
                detail.QuantitySold = detail.QuantitySold;
                detail.Subtotal = detail.UnitCost * detail.QuantitySold;
                detail.Tax = detail.Subtotal * (19 / 100);
                detail.Total = detail.Subtotal + detail.Tax;
                _invoiceDetailRepository.Add(detail);

                // disminuir la cantidad de productos en stock
                produSelected.Stock -= detail.QuantitySold;
                _productRepository.Edit(produSelected);

                invoice.Subtotal += detail.Subtotal;
                invoice.Tax += detail.Tax;
                invoice.Total = detail.Total;
            });

            _invoiceRepository.SaveAllChanges();
            return newInvoice;
        }

        public void Anular(int id)
        {
           _invoiceRepository.Anular(id);
            _invoiceRepository.SaveAllChanges(); 
        }

        public List<Invoice> GetAll()
        {
            return _invoiceRepository.GetAll();
        }

        public Invoice GetById(int id)
        {
            return _invoiceRepository.GetById(id);
        }
    }
}
