using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class ProveedoresActividade
    {
        public int Id { get; set; }
        public int? ProveedorId { get; set; }
        public int? ActividadId { get; set; }

        public virtual Actividade Actividad { get; set; }
        public virtual Proveedore Proveedor { get; set; }
    }
}
