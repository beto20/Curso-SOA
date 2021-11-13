using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class Perfile
    {
        public Perfile()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Perfil { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
