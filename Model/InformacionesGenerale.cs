using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class InformacionesGenerale
    {
        public InformacionesGenerale()
        {
            PaquetesInformacions = new HashSet<PaquetesInformacion>();
        }

        public int Id { get; set; }
        public string InformacionGeneral { get; set; }
        public string DetalleInformacionGeneral { get; set; }
        public int? MostrarBusqueda { get; set; }
        public string Icons { get; set; }

        public virtual ICollection<PaquetesInformacion> PaquetesInformacions { get; set; }
    }
}
