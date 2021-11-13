using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Transfer
{
    public class DisponiblePaquetedt
    {
        public int Id { get; set; }
        public string PaqueteTuristico { get; set; }
        public string HoraInicio { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public int? Cantidad { get; set; }
        public decimal? MontoTotal { get; set; }
        public string Moneda { get; set; }
        public string Simbolo { get; set; }
        public string FechaCancelacion { get; set; }
    }
}
