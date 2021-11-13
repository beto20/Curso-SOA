using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class Rating
    {
        public int Id { get; set; }
        public decimal? Rating1 { get; set; }
        public int? PaquetesTuristicoId { get; set; }
        public int? UsuarioId { get; set; }

        public virtual PaquetesTuristico PaquetesTuristico { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
