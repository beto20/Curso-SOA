using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class Reserva
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPaqueteTuristico { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int Estado { get; set; }
    }
}
