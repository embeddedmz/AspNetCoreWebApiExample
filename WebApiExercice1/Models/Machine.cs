using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cegefos.Api.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Processeur { get; set; }
        public string Memoire { get; set; }
        public string Capacite { get; set; }
        public double Taille_Ecran { get; set; }
    }
}
