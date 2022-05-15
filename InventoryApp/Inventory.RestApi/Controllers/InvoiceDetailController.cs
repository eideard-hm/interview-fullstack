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
    public class InvoiceDetailController : ControllerBase
    {
        static InvoiceDetailService CreateService()
        {
            InvoiceContext db = new();
            InvoiceDetailRepository repository = new(db);
            InvoiceDetailService service = new(repository);
            return service;
        }
        // GET: api/<InvoiceDetailController>
        [HttpGet]
        public ActionResult<List<InvoiceDetail>> GetAll()
        {
            var service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<InvoiceDetailController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var service = CreateService();
            return Ok(service.GetById(id));
        }
    }
}
