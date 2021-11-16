using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class Rating
    {
        public int Id { get; set; }
        public decimal? Rating1 { get; set; }
        public int? IdPaqueteTuristico { get; set; }
    }
}
