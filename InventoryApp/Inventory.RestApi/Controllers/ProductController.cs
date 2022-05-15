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
    public class ProductController : ControllerBase
    {
        static ProductService CreateService()
        {
            InvoiceContext db = new();
            ProductRepository repository = new(db);
            ProductService service = new(repository);
            return service;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            var service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Save(Product product)
        {
            var service = CreateService();
            service.Add(product);
            return Ok(new { message = "El producto se ha guardado correctamente!" });
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest("Los ids del producto no coinciden.");
            }
            var service = CreateService();
            service.Edit(product);
            return Ok(new
            {
                message = "Producto modificado correctamente"
            });
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = CreateService();
            service.Delete(id);
            return Ok(new
            {
                message = "Producto eliminado correctamente!"
            });
        }
    }
}
