using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class Actividade
    {
        public int Id { get; set; }
        public int? IdPadre { get; set; }
        public string Actividad { get; set; }
    }
}
