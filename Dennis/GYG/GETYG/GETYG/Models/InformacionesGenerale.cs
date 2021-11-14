using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class InformacionesGenerale
    {
        public int Id { get; set; }
        public string InformacionGeneral { get; set; }
        public string DetalleInformacionGeneral { get; set; }
        public int? MostrarBusqueda { get; set; }
    }
}
