using System;
using System.Collections.Generic;

#nullable disable

namespace GETYG.Models
{
    public partial class Categoria
    {
        public int Id { get; set; }
        public string Categorias { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
