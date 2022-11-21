using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cegefos.Api.Models
{
    public class Salle
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public virtual Machine Machines { get; set; }
        public int Nombre_De_Places { get; set; }
    }
}