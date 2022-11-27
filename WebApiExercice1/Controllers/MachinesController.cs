using Cegefos.Api.Classes;
using Cegefos.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
