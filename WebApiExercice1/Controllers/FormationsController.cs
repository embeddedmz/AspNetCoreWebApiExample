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
    [ApiVersion("1.0")]
    //[Route("[controller]")]
    [Route("Formations")]
    [ApiController]
    public class FormationsController : ControllerBase
    {
        private CegefosContext _context;
        public FormationsController(CegefosContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetFormations([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<Formation> formations = _context.Formations;

            if (!string.IsNullOrEmpty(queryParameters.Libelle))
            {
                formations = formations.Where(f => f.Libelle.Contains(queryParameters.Libelle, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy == "asc")
                {
                    formations = formations.OrderBy(f => f.Id);
                }
                else if (queryParameters.SortBy == "desc")
                {
                    formations = formations.OrderByDescending(f => f.Id);
                }
            }

            formations = formations
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(formations.Include(f => f.Cours).Include(f => f.Salle).ToList());
        }

        [HttpGet("{formationId}")]
        public IActionResult GetFormationById(int formationId)
        {
            var formation = _context.Formations.Find(formationId);
            if (formation != null)
            {
                return Ok(formation);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Formation> PostFormation([FromBody] Formation formation)
        {
            _context.Formations.Add(formation);
            _context.SaveChanges();

            return CreatedAtAction("PostFormation", new { id = formation.Id }, formation);
        }

        [HttpPut("{id}")]
        public IActionResult PutFormation([FromRoute] int id, [FromBody] Formation formation)
        {
            if (id != formation.Id)
            {
                return BadRequest();
            }

            _context.Entry(formation).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                if (!_context.Formations.Any(f => f.Id == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Formation> DeleteFormation(int id)
        {
            Formation formation = _context.Formations.Find(id);
            if (formation == null)
            {
                return NotFound();
            }

            _context.Formations.Remove(formation);
            _context.SaveChanges();

            return formation;
        }
    }

    [ApiVersion("2.0")]
    //[Route("[controller]")]
    [Route("Formations")]
    [ApiController]
    public class FormationsControllerV2 : ControllerBase
    {
        private CegefosContext _context;
        public FormationsControllerV2(CegefosContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetFormations([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<Formation> formations = _context.Formations;

            if (!string.IsNullOrEmpty(queryParameters.Libelle))
            {
                formations = formations.Where(f => f.Libelle.Contains(queryParameters.Libelle, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy == "asc")
                {
                    formations = formations.OrderBy(f => f.Id);
                }
                else if (queryParameters.SortBy == "desc")
                {
                    formations = formations.OrderByDescending(f => f.Id);
                }
            }

            formations = formations
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(formations.Include(f => f.Cours).Include(f => f.Salle).ToList());
        }

        [HttpGet("{formationId}")]
        public IActionResult GetFormationById(int formationId)
        {
            var formation = _context.Formations.Find(formationId);
            if (formation != null)
            {
                return Ok(formation);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Formation> PostFormation([FromBody] Formation formation)
        {
            _context.Formations.Add(formation);
            _context.SaveChanges();

            return CreatedAtAction("PostFormation", new { id = formation.Id }, formation);
        }

        [HttpPut("{id}")]
        public IActionResult PutFormation([FromRoute] int id, [FromBody] Formation formation)
        {
            if (id != formation.Id)
            {
                return BadRequest();
            }

            _context.Entry(formation).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                if (!_context.Formations.Any(f => f.Id == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Formation> DeleteFormation(int id)
        {
            Formation formation = _context.Formations.Find(id);
            if (formation == null)
            {
                return NotFound();
            }

            _context.Formations.Remove(formation);
            _context.SaveChanges();

            return formation;
        }
    }
}
