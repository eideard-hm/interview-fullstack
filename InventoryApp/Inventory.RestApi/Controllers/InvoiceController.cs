using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Context;
using Inventory.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        static InvoiceService CreateService()
        {
            InvoiceContext db = new();
            InvoiceRepository invoiceRepository = new(db);
            ProductRepository productRepository = new(db);
            InvoiceDetailRepository invoiceDetailRepository = new(db);
            InvoiceService service = new(invoiceRepository, productRepository, invoiceDetailRepository);
            return service;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public ActionResult<List<Invoice>> GetAll()
        {
            var service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public ActionResult<Invoice> GetById(int id)
        {
            var service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public ActionResult Add(Invoice invoice)
        {
            var service = CreateService();
            service.Add(invoice);
            return Ok(new { message = "Facturada guardada correctamente!" });
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public ActionResult Anular(int id)
        {
            var service = CreateService();
            service.Anular(id);
            return Ok();
        }
    }
}
