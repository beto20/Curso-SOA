using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class PesonasJuridica
    {
        public int Id { get; set; }
        public string NombreCompania { get; set; }
        public int? IdRepresentanteLegal { get; set; }
        public string Direccion { get; set; }
        public string Ubicacion { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
    }
}
