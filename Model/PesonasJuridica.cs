using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class PesonasJuridica
    {
        public PesonasJuridica()
        {
            Clientes = new HashSet<Cliente>();
            Proveedores = new HashSet<Proveedore>();
        }

        public int Id { get; set; }
        public string NombreCompania { get; set; }
        public int? PersonaId { get; set; }
        public string Direccion { get; set; }
        public string Ubicacion { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Proveedore> Proveedores { get; set; }
    }
}
