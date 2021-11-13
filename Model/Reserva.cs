using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class Reserva
    {
        public Reserva()
        {
            FacturacionesDetalles = new HashSet<FacturacionesDetalle>();
        }

        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? PaquetesTuristicoId { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int Estado { get; set; }
        public int CantidadPersonas { get; set; }

        public virtual PaquetesTuristico PaquetesTuristico { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<FacturacionesDetalle> FacturacionesDetalles { get; set; }
    }
}
