using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class ProveedoresActividade
    {
        public int Id { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdActividad { get; set; }
    }
}
