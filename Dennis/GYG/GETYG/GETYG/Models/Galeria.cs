using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class Galeria
    {
        public int Id { get; set; }
        public int? IdPaqueteTuristico { get; set; }
        public string Url { get; set; }
    }
}
