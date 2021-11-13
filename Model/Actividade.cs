using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class Actividade
    {
        public Actividade()
        {
            InverseIdPadreNavigation = new HashSet<Actividade>();
            PaquetesTuristicos = new HashSet<PaquetesTuristico>();
            ProveedoresActividades = new HashSet<ProveedoresActividade>();
        }

        public int Id { get; set; }
        public int? IdPadre { get; set; }
        public string Actividad { get; set; }

        public virtual Actividade IdPadreNavigation { get; set; }
        public virtual ICollection<Actividade> InverseIdPadreNavigation { get; set; }
        public virtual ICollection<PaquetesTuristico> PaquetesTuristicos { get; set; }
        public virtual ICollection<ProveedoresActividade> ProveedoresActividades { get; set; }
    }
}
