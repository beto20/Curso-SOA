using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class PaquetesInformacion
    {
        public int Id { get; set; }
        public int PaquetesTuristicoId { get; set; }
        public int InformacionesGeneraleId { get; set; }

        public virtual InformacionesGenerale InformacionesGenerale { get; set; }
        public virtual PaquetesTuristico PaquetesTuristico { get; set; }
    }
}
