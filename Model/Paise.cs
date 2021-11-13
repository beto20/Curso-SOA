using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class Paise
    {
        public Paise()
        {
            PaquetesTuristicos = new HashSet<PaquetesTuristico>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string Pais { get; set; }

        public virtual ICollection<PaquetesTuristico> PaquetesTuristicos { get; set; }
    }
}
