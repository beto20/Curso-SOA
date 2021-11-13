using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturaciones = new HashSet<Facturacione>();
        }

        public int Id { get; set; }
        public int? PersonaId { get; set; }
        public int? PersonasJuridicaId { get; set; }
        public int? TipoPersona { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual PesonasJuridica PersonasJuridica { get; set; }
        public virtual ICollection<Facturacione> Facturaciones { get; set; }
    }
}
