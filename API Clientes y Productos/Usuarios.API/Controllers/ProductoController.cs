using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Usuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private static IList<Producto> lista = new List<Producto>();

        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return lista.OrderBy(x => x.Id);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public Producto Get(int id)
        {
            return lista.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public void Post([FromBody] Producto producto)
        {
            lista.Add(producto);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Producto producto)
        {
            Producto finded = lista.FirstOrDefault(x => x.Id == id);
            finded.Description = producto.Description;
            finded.Price = producto.Price;
            finded.Stock = producto.Stock;
        }

        // PUT api/<ProductoController>/5/reducirstock
        [HttpPut("{id}/reducirstock")]
        public void ReduceStock(int id, [FromBody] int units)
        {
            Producto finded = lista.FirstOrDefault(x => x.Id == id);
            finded.Stock -= units;
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            lista.Remove(lista.FirstOrDefault(x => x.Id == id));
        }
    }
}
