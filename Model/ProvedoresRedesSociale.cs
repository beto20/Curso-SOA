using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class ProvedoresRedesSociale
    {
        public int Id { get; set; }
        public int? ProveedorId { get; set; }
        public int? RedesSocialesId { get; set; }

        public virtual Proveedore Proveedor { get; set; }
        public virtual RedesSociale RedesSociales { get; set; }
    }
}
