using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Tribulo.Context;
using SWProvincias_Tribulo.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Tribulo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {

        private readonly DBPaisFinalContext context;

        public CiudadController(DBPaisFinalContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {

            return context.Ciudades.ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Ciudad> GetById(int id)
        {

            var ciudad = context.Ciudades.FirstOrDefault(c => c.IdCiudad == id);

            if (ciudad == null)
            {
                return NotFound();
            }

            return ciudad;

        }

        [HttpPost]
        public ActionResult<Ciudad> Post(Ciudad ciudad)
        {

            if (!ModelState.IsValid) return BadRequest();

            context.Ciudades.Add(ciudad);
            context.SaveChanges();

            return Ok();

        }

        [HttpPut("{id}")]
        public ActionResult<Ciudad> Put(int id, [FromBody] Ciudad ciudad)
        {

            if (id != ciudad.IdCiudad) return BadRequest();

            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult<Ciudad> Delete(int id)
        {

            var ciudad = (
                    from c in context.Ciudades
                    where c.IdCiudad == id
                    select c
                ).FirstOrDefault();

            if (ciudad == null) return NotFound();

            context.Ciudades.Remove(ciudad);
            context.SaveChanges();

            return Ok();

        }
    }
}
