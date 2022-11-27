using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cegefos.Api.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Titre { get; set; }
        public int Durée { get; set; }
        public string Programme { get; set; }

        [JsonIgnore]
        public virtual List<Formation> Formations { get; set; }
    }
}
