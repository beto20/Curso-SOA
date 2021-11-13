using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class Pago
    {
        public int Id { get; set; }
        public int? FacturaId { get; set; }
        public string TipoTarjeta { get; set; }

        public virtual Facturacione Factura { get; set; }
    }
}
