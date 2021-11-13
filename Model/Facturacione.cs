using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class Facturacione
    {
        public Facturacione()
        {
            FacturacionesDetalles = new HashSet<FacturacionesDetalle>();
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? TipoPersona { get; set; }
        public string Documento { get; set; }
        public string RazonSocial { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public decimal? TipoDeCambio { get; set; }
        public string Moneda { get; set; }
        public string Simbolo { get; set; }
        public decimal? MontoTotal { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<FacturacionesDetalle> FacturacionesDetalles { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
