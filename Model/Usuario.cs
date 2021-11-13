using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class Usuario
    {
        public Usuario()
        {
            Favoritos = new HashSet<Favorito>();
            Ratings = new HashSet<Rating>();
            Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public int? PersonaId { get; set; }
        public int? PerfilId { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public DateTime? FechaUltimaIngreso { get; set; }

        public virtual Perfile Perfil { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ICollection<Favorito> Favoritos { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
