using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Transfer;

namespace WebApi.Model
{
    public partial class PaquetesInformacion
    {
        public static IEnumerable<PaquetesInformaciondt> VerInformacionGeneral(int id)
        {
            SOIContext db = new SOIContext();
            var list = from b in db.PaquetesInformacions.Where(t => t.PaquetesTuristicoId == id)
                       select new PaquetesInformaciondt()
                       {
                           Id = b.Id,
                           Informacion = new InformacionesGeneraledt()
                           {
                               Id = b.InformacionesGenerale.Id,
                               InformacionGeneral = b.InformacionesGenerale.InformacionGeneral,
                               DetalleInformacionGeneral = b.InformacionesGenerale.DetalleInformacionGeneral
                           }
                       };
            return list;
        }
    }
}
