using Cegefos.Api.Classes;
using Cegefos.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cegefos.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private CegefosContext _context;

        public MachinesController(CegefosContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetMachines([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<Machine> machines = _context.Machines;

            if (!string.IsNullOrEmpty(queryParameters.Libelle))
            {
                machines = machines.Where(m => m.Libelle.Contains(queryParameters.Libelle,
                    StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy == "asc")
                {
                    machines = machines.OrderBy(m => m.Id);
                }
                else if (queryParameters.SortBy == "desc")
                {
                    machines = machines.OrderByDescending(m => m.Id);
                }
            }

            machines = machines
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(machines.ToList());
        }

        [HttpGet("{machineId}")]
        public IActionResult GetMachineById(int machineId)
        {
            var machine = _context.Machines.Find(machineId);
            if (machine != null)
            {
                return Ok(machine);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Machine> PostMachine([FromBody] Machine machine)
        {
            _context.Machines.Add(machine);
            _context.SaveChanges();

            return CreatedAtAction("PostMachine", new { id = machine.Id }, machine);
        }

        [HttpPut("{id}")]
        public IActionResult PutMachine([FromRoute] int id, [FromBody] Machine machine)
        {
            if (id != machine.Id)
            {
                return BadRequest();
            }

            _context.Entry(machine).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                if (!_context.Machines.Any(m => m.Id == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Machine> DeleteMachine(int id)
        {
            Machine machine = _context.Machines.Find(id);
            if (machine == null)
            {
                return NotFound();
            }

            _context.Machines.Remove(machine);
            _context.SaveChanges();

            return machine;
        }
    }
}
