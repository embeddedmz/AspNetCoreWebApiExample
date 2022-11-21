using Cegefos.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cegefos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CegefosController : ControllerBase
    {
        private readonly CegefosContext _context;

        public CegefosController(CegefosContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<Salle> GetSalles()
        {
            return _context.Salles.ToArray();
        }
    }
}
