using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWAdventureWorks_Tribulo.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SWAdventureWorks_Tribulo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly AdventureWorks2019Context context;

        public DepartmentController (AdventureWorks2019Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Department>> Get()
        {

            return context.Departments.ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetById(int id)
        {

            var department = context.Departments.FirstOrDefault(d => d.DepartmentId == id);

            if (department == null) return NotFound();

            return department;

        }

        [HttpGet("name/{name}")]

        public ActionResult<Department> GetByName(string name)
        {

            var departmant = (
                    from d in context.Departments
                    where d.Name == name
                    select d
                ).FirstOrDefault();

            if (departmant == null) return NotFound();

            return departmant;

        }

        [HttpPost]

        public ActionResult<Department> Post(Department department)
        {

            if (!ModelState.IsValid) return BadRequest();

            context.Departments.Add(department);
            context.SaveChanges();

            return Ok();
        }


    }
}
