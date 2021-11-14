using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class ProvedoresRedesSociale
    {
        public int Id { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdRedesSociales { get; set; }
    }
}
