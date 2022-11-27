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
    public class CoursController : ControllerBase
    {
        private CegefosContext _context;

        public CoursController(CegefosContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetCours([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<Cours> cours = _context.Cours;
            if (!string.IsNullOrEmpty(queryParameters.Libelle))
            {
                cours = cours.Where(c => c.Titre.Contains(queryParameters.Libelle,
                    StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy == "asc")
                {
                    cours = cours.OrderBy(c => c.Id);
                }
                else if (queryParameters.SortBy == "desc")
                {
                    cours = cours.OrderByDescending(c => c.Id);
                }
            }

            cours = cours
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(cours.ToList());
        }

        [HttpGet("{coursId}")]
        public IActionResult GetCoursById(int coursId)
        {
            var cours = _context.Cours.Find(coursId);
            if (cours != null)
            {
                return Ok(cours);
            }

            return NotFound();
        }
    }
}
