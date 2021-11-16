using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class Favorito
    {
        public int Id { get; set; }
        public int? IdPaqueteTuristico { get; set; }
        public int? IdUsuario { get; set; }
        public int? Estado { get; set; }
    }
}
