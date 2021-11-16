using GETYG.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETYG.Models
{
    public partial class PaquetesTuristico
    {

        public static List<DtoPaqueteTuristico> ListarPaquetesTuristicos(string _Ubicacion, DateTime _fechaIda, DateTime _fechaRegreso)
        {
            GYGContext db = new GYGContext();
            IEnumerable<PaquetesTuristico> _listaPaqueteTuristico;

            if (_fechaIda != DateTime.MinValue && _fechaRegreso != DateTime.MinValue)
                _listaPaqueteTuristico = db.PaquetesTuristicos.Where(x => x.Ubicacion.Contains(_Ubicacion) && x.FechaInicio >= _fechaIda && x.FechaFin <= _fechaRegreso && x.Estado == 1).ToList();
            else if (_fechaIda != DateTime.MinValue && _fechaRegreso == DateTime.MinValue)
                _listaPaqueteTuristico = db.PaquetesTuristicos.Where(x => x.Ubicacion.Contains(_Ubicacion) && x.FechaInicio >= _fechaIda && x.Estado == 1).ToList();
            else if (_fechaIda == DateTime.MinValue && _fechaRegreso != DateTime.MinValue)
                _listaPaqueteTuristico = db.PaquetesTuristicos.Where(x => x.Ubicacion.Contains(_Ubicacion) && x.FechaFin <= _fechaRegreso && x.Estado == 1).ToList();
            else
                _listaPaqueteTuristico = db.PaquetesTuristicos.Where(x => x.Ubicacion.Contains(_Ubicacion) && x.Estado == 1).ToList();

            List<DtoPaqueteTuristico> _listaRetornoDTO = ConvertirListaDTO(_listaPaqueteTuristico);

            BuscarReservasPaquetes(_listaRetornoDTO);

            return _listaRetornoDTO;
        }

        private static List<DtoPaqueteTuristico> ConvertirListaDTO(IEnumerable<PaquetesTuristico> _listaPaquetes)
        {
            List<DtoPaqueteTuristico> _listaRetorno = new List<DtoPaqueteTuristico>();
            DtoPaqueteTuristico dto;

            foreach (var item in _listaPaquetes)
            {
                dto = new DtoPaqueteTuristico();
                dto.Id = item.Id;
                dto.IdProveedor = item.IdProveedor;
                dto.IdCategoria = item.IdCategoria;
                dto.PaqueteTuristico = item.PaqueteTuristico;
                dto.Descripcion = item.Descripcion;
                dto.PrecioUnitario = item.PrecioUnitario;
                dto.Moneda = item.Moneda;
                dto.Simbolo = item.Simbolo;
                dto.MaxNumeroPersonas = item.MaxNumeroPersonas;
                dto.EsFlexible = item.EsFlexible;
                dto.TiempoDuracion = item.TiempoDuracion;
                dto.UnidadDuracion = item.UnidadDuracion;
                dto.FechaInicio = item.FechaInicio;
                dto.FechaFin = item.FechaFin;
                dto.Ubicacion = item.Ubicacion;
                dto.Estado = item.Estado;
                _listaRetorno.Add(dto);
            }

            return _listaRetorno;
        }


        private static void BuscarReservasPaquetes(List<DtoPaqueteTuristico> _listaPaquetes)
        {
            GYGContext db = new GYGContext();

            foreach (var item in _listaPaquetes)
            {
                var _list = db.Reservas.Where(x => x.IdPaqueteTuristico == item.Id);

                if (_list.Count() == item.MaxNumeroPersonas)
                    item.EstadoPaqueteTuristico = "No Disponible";
                else
                    item.EstadoPaqueteTuristico = "Disponible";
            }

        }






    }
}
