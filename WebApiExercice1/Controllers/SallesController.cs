using Cegefos.Api.Classes;
using Cegefos.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cegefos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SallesController : ControllerBase
    {
        private readonly CegefosContext _context;

        public SallesController(CegefosContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetSalles([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<Salle> salles = _context.Salles;

            if (!string.IsNullOrEmpty(queryParameters.Libelle))
            {
                salles = salles.Where(s => s.Libelle.Contains(queryParameters.Libelle,
                    StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy == "asc")
                {
                    salles = salles.OrderBy(s => s.Id);
                }
                else if (queryParameters.SortBy == "desc")
                {
                    salles = salles.OrderByDescending(s => s.Id);
                }
            }

            salles = salles
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(salles.ToList());
        }

        [HttpGet("{salleId}")]
        public IActionResult GetSalleById(int salleId)
        {
            var salle = _context.Salles.Find(salleId);
            if (salle != null)
            {
                return Ok(salle);
            }
            
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Salle> PostSalle([FromBody] Salle salle)
        {
            _context.Salles.Add(salle);
            _context.SaveChanges();

            return CreatedAtAction("PostSalle", new { id = salle.Id }, salle);
        }

        [HttpPut("{id}")]
        public IActionResult PutSalle([FromRoute] int id, [FromBody] Salle salle)
        {
            if (id != salle.Id)
            {
                return BadRequest();
            }

            _context.Entry(salle).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                if (!_context.Salles.Any(salle => salle.Id == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Salle> DeleteSalle(int id)
        {
            Salle salle = _context.Salles.Find(id);
            if (salle == null)
            {
                return NotFound();
            }

            _context.Salles.Remove(salle);
            _context.SaveChanges();

            return salle;
        }
    }
}
