using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class Facturacione
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? TipoPersona { get; set; }
        public string Documento { get; set; }
        public string RazonSocial { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public decimal? TipoDeCambio { get; set; }
        public string Moneda { get; set; }
        public string Simbolo { get; set; }
        public decimal? MontoTotal { get; set; }
    }
}
