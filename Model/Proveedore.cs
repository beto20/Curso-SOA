using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            PaquetesTuristicos = new HashSet<PaquetesTuristico>();
            ProvedoresRedesSociales = new HashSet<ProvedoresRedesSociale>();
            ProveedoresActividades = new HashSet<ProveedoresActividade>();
        }

        public int Id { get; set; }
        public int? PersonaId { get; set; }
        public int? PersonasJuridicaId { get; set; }
        public int? TipoPersona { get; set; }
        public string Moneda { get; set; }
        public int Estado { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual PesonasJuridica PersonasJuridica { get; set; }
        public virtual ICollection<PaquetesTuristico> PaquetesTuristicos { get; set; }
        public virtual ICollection<ProvedoresRedesSociale> ProvedoresRedesSociales { get; set; }
        public virtual ICollection<ProveedoresActividade> ProveedoresActividades { get; set; }
    }
}
