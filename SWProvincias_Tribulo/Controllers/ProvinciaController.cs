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
    public class ProvinciaController : ControllerBase
    {

        private readonly DBPaisFinalContext context;

        public ProvinciaController(DBPaisFinalContext context)
        {

            this.context = context;

        }


        [HttpGet]

        public ActionResult<IEnumerable<Provincia>> Get() {

            return context.Provincias.ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Provincia> GetById(int id)
        {

            var provincia = context.Provincias.FirstOrDefault(p => p.IdProvincia == id);

            if (provincia == null)
            {
                return NotFound();
            }

            return provincia;

        }

        [HttpPost]
        public ActionResult<Provincia> Post(Provincia provincia)
        {

            if (!ModelState.IsValid) return BadRequest();

            context.Provincias.Add(provincia);
            context.SaveChanges();

            return Ok();

        }

        [HttpPut("{id}")]
        public ActionResult<Provincia> Put(int id, [FromBody] Provincia provincia)
        {

            if (id != provincia.IdProvincia) return BadRequest();

            context.Entry(provincia).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult<Provincia> Delete(int id)
        {

            var provincia = (
                    from p in context.Provincias
                    where p.IdProvincia == id
                    select p
                ).FirstOrDefault();

            if (provincia == null) return NotFound();

            context.Provincias.Remove(provincia);
            context.SaveChanges();

            return Ok();

        }
    }
}
