using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class PaquetesTuristico
    {
        public PaquetesTuristico()
        {
            Favoritos = new HashSet<Favorito>();
            Galeria = new HashSet<Galeria>();
            PaquetesInformacions = new HashSet<PaquetesInformacion>();
            Ratings = new HashSet<Rating>();
            Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public int IdCategoria { get; set; }
        public int? ActividadId { get; set; }
        public int IdPais { get; set; }
        public string PaqueteTuristico { get; set; }
        public string Descripcion { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public string Moneda { get; set; }
        public string Simbolo { get; set; }
        public int? MaxNumeroPersonas { get; set; }
        public int? EsFlexible { get; set; }
        public decimal? TiempoDuracion { get; set; }
        public string UnidadDuracion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Ubicacion { get; set; }
        public int Estado { get; set; }

        public virtual Actividade Actividad { get; set; }
        public virtual Paise IdPaisNavigation { get; set; }
        public virtual Proveedore Proveedor { get; set; }
        public virtual ICollection<Favorito> Favoritos { get; set; }
        public virtual ICollection<Galeria> Galeria { get; set; }
        public virtual ICollection<PaquetesInformacion> PaquetesInformacions { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
