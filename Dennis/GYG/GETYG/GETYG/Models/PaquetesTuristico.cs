using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class PaquetesTuristico
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int? IdCategoria { get; set; }
        public string PaqueteTuristico { get; set; }
        public string Descripcion { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public string Moneda { get; set; }
        public string Simbolo { get; set; }
        public int? MaxNumeroPersonas { get; set; }
        public int? EsFlexible { get; set; }
        public decimal? TiempoDuracion { get; set; }
        public string UnidadDuracion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Ubicacion { get; set; }
        public int Estado { get; set; }

        
    }
}
