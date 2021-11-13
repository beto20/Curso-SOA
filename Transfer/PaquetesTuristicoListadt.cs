using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Transfer
{
    public class PaquetesTuristicoListadt
    {
        public int Id { get; set; }
        public string PaqueteTuristico { get; set; }
        public string Descripcion { get; set; }
        public string Moneda { get; set; }
        public string Simbolo { get; set; }
        public decimal? Preciounitario { get; set; }
        public decimal? TiempoDuracion { get; set; }
        public string UnidadDuracion { get; set; }
        public decimal? PrecioUnitario { get; set; }
    }
}
