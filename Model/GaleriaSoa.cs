using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Transfer;

namespace WebApi.Model
{
    public partial class Galeria
    {
        public static IEnumerable<Galeriadt> VerGaleriaFotos(int id)
        {
            SOIContext db = new SOIContext();
            var lista = from b in db.Galerias.Where(t => t.PaquetesTuristicoId == id)
                        select new Galeriadt() {
                            Id = b.Id,
                            Url = b.Url
            };
            return lista;
        }
    }
}
