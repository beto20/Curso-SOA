using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class FacturacionesDetalle
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public int IdFacturacion { get; set; }
        public int? CantidadPersonas { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? PrecioTotal { get; set; }
    }
}
