using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class PaquetesInformacion
    {
        public int Id { get; set; }
        public int IdPaqueteTuristico { get; set; }
        public int IdInformacionGeneral { get; set; }
    }
}
