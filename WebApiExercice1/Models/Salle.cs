using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cegefos.Api.Models
{
    public class Salle
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public virtual List<Machine> Machines { get; set; }
        public int Nombre_De_Places { get; set; }

        [JsonIgnore]
        public virtual List<Formation> Formations { get; set; }
    }
}