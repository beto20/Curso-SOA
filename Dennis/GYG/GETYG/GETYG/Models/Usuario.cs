using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public int? IdPersona { get; set; }
        public int? IdPerfil { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public DateTime? FechaUltimaIngreso { get; set; }
        public bool? IbCorreoValido { get; set; }
    }
}
