using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cegefos.Api.Models
{
    public class Formation
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public Cours Cours { get; set; }
        public Salle Salle { get; set; }
        public DateTime DateDebut { get; set; }
    }
}
