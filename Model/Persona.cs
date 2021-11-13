using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class Persona
    {
        public Persona()
        {
            Clientes = new HashSet<Cliente>();
            PesonasJuridicas = new HashSet<PesonasJuridica>();
            Proveedores = new HashSet<Proveedore>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Ubicacion { get; set; }
        public string Telefono { get; set; }
        public string CodigoPostal { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<PesonasJuridica> PesonasJuridicas { get; set; }
        public virtual ICollection<Proveedore> Proveedores { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
