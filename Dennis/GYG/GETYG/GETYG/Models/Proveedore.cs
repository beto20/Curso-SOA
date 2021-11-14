using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class Proveedore
    {
        public int Id { get; set; }
        public int? IdPersona { get; set; }
        public int? IdPersonaJuridica { get; set; }
        public int? TipoPersona { get; set; }
        public string Moneda { get; set; }
        public int Estado { get; set; }
    }
}
