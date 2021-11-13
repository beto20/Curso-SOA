using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class FacturacionesDetalle
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public int FacturacionId { get; set; }
        public int? CantidadPersonas { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? PrecioTotal { get; set; }

        public virtual Facturacione Facturacion { get; set; }
        public virtual Reserva Reserva { get; set; }
    }
}
