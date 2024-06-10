using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Usuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private static IList<Cliente> lista = new List<Cliente>();

        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return lista.OrderBy(x => x.Id);
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            return lista.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void Post(Cliente cliente)
        {
            lista.Add(cliente);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cliente cliente)
        {
            Cliente finded = lista.FirstOrDefault(x => x.Id == id);
            finded.FirstName = cliente.FirstName;
            finded.LastName = cliente.LastName;
            finded.Email = cliente.Email;
            finded.Address = cliente.Address;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            lista.Remove(lista.FirstOrDefault(x => x.Id == id));
        }
    }
}
