using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class Pago
    {
        public int Id { get; set; }
        public int? IdFactura { get; set; }
        public string TipoTarjeta { get; set; }
    }
}
