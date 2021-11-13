using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Transfer
{
    public class Usuariodt
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaUltimaIngreso { get; set; }
    }
}
