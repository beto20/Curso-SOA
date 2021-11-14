using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETYG.Models
{
    public partial class PaquetesTuristico
    {

        public static IEnumerable<PaquetesTuristico> BuscarPaquetesTuristicos(string _Ubicacion, DateTime _fechaIda, DateTime _fechaRegreso)
        {
            GYGContext db = new GYGContext();

            if (_fechaIda != DateTime.MinValue && _fechaRegreso != DateTime.MinValue)
            {
                var _list = db.PaquetesTuristicos.Where(x => x.Ubicacion.Contains(_Ubicacion) && x.FechaInicio >= _fechaIda && x.FechaFin <= _fechaRegreso).ToList();
                return _list;
            }
            else if (_fechaIda != DateTime.MinValue && _fechaRegreso == DateTime.MinValue)
            {
                var _list = db.PaquetesTuristicos.Where(x => x.Ubicacion.Contains(_Ubicacion) && x.FechaInicio >= _fechaIda).ToList();
                return _list;
            }
            else if (_fechaIda == DateTime.MinValue && _fechaRegreso != DateTime.MinValue)
            {
                var _list = db.PaquetesTuristicos.Where(x => x.Ubicacion.Contains(_Ubicacion) && x.FechaFin <= _fechaRegreso).ToList();
                return _list;
            }
            else
            {
                var _list = db.PaquetesTuristicos.Where(x => x.Ubicacion.Contains(_Ubicacion)).ToList();
                return _list;
            }
        }







    }
}
