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
    public class UserController : ControllerBase
    {
        static UserService CreateService()
        {
            InvoiceContext db = new();
            UserRepository repository = new(db);
            UserService userService = new(repository);
            return userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            var service = CreateService();
            return Ok(service.GetAll());    
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Add(User user)
        {
            var service = CreateService();
            service.Add(user);
            return Ok("Se ha creado correctamente el usuario!");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, User user)
        {
            if(id != user.UserId)
            {
                return BadRequest("Los Ids no coinciden!");
            }
            var service = CreateService();
            service.Edit(user);
            return Ok("Se ha modificado correctamente el usuario!");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = CreateService();
            service.Delete(id);
            return Ok("Se ha eliminado correctamente el usuario");
        }
    }
}
