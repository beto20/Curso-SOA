using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Transfer;

namespace WebApi.Model
{
    public partial class PaquetesTuristico
    {
        static string unidad = "";
        static decimal? valor = 0;
        static int? valordia = 0;
        static DateTime? fechafin;
        static DateTime? fechainicio;
        static int? idrese = 0;
        static string msn = "Puede Reservar";
        static string textofecha = "";
        static string fechaauxiliar;
        static string horainicio = "";
        public static PaquetesTuristicodt VerPaqueteTuristico(int id)
        {
            SOIContext db = new SOIContext();
            var obj = db.PaquetesTuristicos
                .Select(b => new PaquetesTuristicodt()
                {
                    Id = b.Id,
                    PaqueteTuristico = b.PaqueteTuristico,
                    Descripcion = b.Descripcion,
                    Moneda = b.Moneda,
                    Simbolo = b.Simbolo,
                    PrecioUnitario = b.PrecioUnitario,
                    TiempoDuracion = b.TiempoDuracion,
                    UnidadDuracion = b.UnidadDuracion
                }).SingleOrDefault(b => b.Id == id);
            if (obj == null) obj = new PaquetesTuristicodt() { Id = 0, PaqueteTuristico = "" };
            return obj;
        }

        public static IEnumerable<PaquetesTuristicodt> ListarPaquetesSugeridos(int idpais, int idcat)
        {
            SOIContext db = new SOIContext();
            var lista = from b in db.PaquetesTuristicos
                        .Where(t => t.IdPais == idpais && t.IdCategoria == idcat).OrderBy(t => t.PaqueteTuristico)
                        select new PaquetesTuristicodt()
                        {
                            Id = b.Id,
                            PaqueteTuristico = b.PaqueteTuristico,
                            Descripcion = b.Descripcion,
                            Moneda = b.Moneda,
                            Simbolo = b.Simbolo,
                            PrecioUnitario = b.PrecioUnitario,
                            TiempoDuracion = b.TiempoDuracion,
                            UnidadDuracion = b.UnidadDuracion
                        }; 
            return lista;
        }


        public static string Disponible(string fechareserva)
        {
            SOIContext db = new SOIContext();
            
            DateTime temp = Convert.ToDateTime(fechareserva);
            var txtfecha = temp.ToString("dd-MM-yyyy");
            Debug.WriteLine(txtfecha);

            return txtfecha;
        }

        public static DisponiblePaquetedt DisponibilidadPaqueteTuristico(int idpaquete, DateTime fechareserva, int cantidadpersonas)
        {
            SOIContext db = new SOIContext();

            if(idpaquete > 0 && cantidadpersonas > 0)
            {
                DateTime thisDay = DateTime.Today;

                var lista2 = db.PaquetesTuristicos.Where(t => t.Id == idpaquete && t.MaxNumeroPersonas >= cantidadpersonas && fechareserva > thisDay && fechareserva >= t.FechaInicio && fechareserva <= t.FechaFin)
                            .OrderBy(t => t.PaqueteTuristico).ToList();

                foreach (var lis in lista2)
                {
                    unidad = lis.UnidadDuracion.ToUpper();
                    valor = lis.TiempoDuracion;
                    fechainicio = lis.FechaInicio;
                    valordia = Convert.ToInt32(lis.TiempoDuracion);
                    DateTime temp = Convert.ToDateTime(fechainicio);
                    textofecha = temp.ToString("hh:mm");
                }

                if (unidad.Length > 0 && valor > 0)
                {
                    if (unidad == "dias")
                    {
                        DateTime answer = fechareserva.AddDays(Convert.ToInt32(valor));
                        fechafin = answer;
                    }
                    else
                    {
                        DateTime answer = fechareserva.AddHours((double)valor);
                        fechafin = answer;
                    }

                    DateTime temp2 = Convert.ToDateTime(fechainicio);
                    textofecha = temp2.ToString("yyyy-MM-dd") + " " + textofecha + ":00";

                    DateTime temp3 = Convert.ToDateTime(textofecha);
                    CultureInfo culture = new CultureInfo("es-ES");

                    fechaauxiliar = temp3.ToString("U", culture);
                    horainicio = temp3.ToString("HH:MM");


                    var lista3 = db.Reservas
                        .Where(t => t.PaquetesTuristicoId == idpaquete && t.FechaInicio > thisDay && fechareserva >= t.FechaInicio && t.FechaInicio <= fechafin)
                        .ToList();

                    foreach (var li in lista3)
                    {
                        idrese = li.Id;
                    }
                }
            }

            var obj = db.PaquetesTuristicos.Where(t => t.Id == idpaquete)
                      .Select(b => new DisponiblePaquetedt()
                      {
                          Id = b.Id,
                          PaqueteTuristico = b.PaqueteTuristico,
                          PrecioUnitario = b.PrecioUnitario,
                          Moneda = b.Moneda,
                          Simbolo = b.Simbolo,
                          Cantidad = cantidadpersonas,
                          MontoTotal = b.PrecioUnitario * cantidadpersonas,
                          FechaCancelacion = fechaauxiliar,
                          HoraInicio = horainicio
                      }).SingleOrDefault();

            if (obj == null) obj = new DisponiblePaquetedt() { Id = 0 };

            return obj;
        }

        public static DisponiblePaquetedt ValidarPaquete(int idp, DateTime fechareserva, int numper)
        {
            SOIContext db = new SOIContext();

            DateTime thisDay = DateTime.Today;
            
            var lista2 = db.PaquetesTuristicos.Where(t => t.Id == idp && t.MaxNumeroPersonas >= numper && fechareserva > thisDay && fechareserva >= t.FechaInicio && fechareserva <= t.FechaFin)
                        .OrderBy(t => t.PaqueteTuristico).ToList();
            
            foreach(var lis in lista2)
            {
                unidad = lis.UnidadDuracion.ToUpper();
                valor = lis.TiempoDuracion;
                fechainicio = lis.FechaInicio;
                valordia = Convert.ToInt32(lis.TiempoDuracion);
                DateTime temp = Convert.ToDateTime(fechainicio);
                textofecha = temp.ToString("HH:MM");
            }
            Debug.WriteLine("Unidad--> " + unidad);
            Debug.WriteLine("Valor--> " + valor);
            Debug.WriteLine("Fecha Inicio--> " + fechareserva.ToString());
            Debug.WriteLine("Horas--> " + textofecha);
            
            if (unidad.Length >0 && valor > 0) {
                if( unidad == "dias")
                {
                    DateTime answer = fechareserva.AddDays(Convert.ToInt32(valor));
                    fechafin = answer;
                } else
                {
                    DateTime answer = fechareserva.AddHours((double)valor);
                    fechafin = answer;
                }
                Debug.WriteLine("Fecha Fin--> " + fechafin.ToString());
                DateTime temp2 = Convert.ToDateTime(fechainicio);
                textofecha = temp2.ToString("yyyy-MM-dd") + " " + textofecha + ":00";
                Debug.WriteLine("Fecha Erronea-->" + textofecha);
                DateTime temp3 = Convert.ToDateTime(textofecha);
                CultureInfo culture = new CultureInfo("es-ES");
                fechaauxiliar = temp3.ToString("U", culture);
                horainicio = temp3.ToString("HH:MM");

                Debug.WriteLine("fechaauxiliar--> "+ fechaauxiliar);
                var lista3 = db.Reservas
                    .Where(t => t.PaquetesTuristicoId == idp && fechareserva >= t.FechaInicio && t.FechaInicio <= fechafin )
                    .ToList();

                foreach(var li in lista3)
                {
                    idrese = li.Id;
                }

                             
            }

            var obj = db.PaquetesTuristicos.Where(t => t.Id == idp)
                      .Select(b => new DisponiblePaquetedt()
                      {
                          Id = b.Id,
                          PaqueteTuristico = b.PaqueteTuristico,
                          PrecioUnitario = b.PrecioUnitario,
                          Moneda = b.Moneda,
                          Simbolo = b.Simbolo,
                          Cantidad = numper,
                          MontoTotal = b.PrecioUnitario * numper,
                          FechaCancelacion = fechaauxiliar,
                          HoraInicio = horainicio
                      }).SingleOrDefault();

            if (obj == null) obj = new DisponiblePaquetedt() { Id = 0 };

            if (idrese > 0)
            {
                msn = "No Puede Reservar";
            }
                
            Debug.WriteLine(msn); 

            return obj;
        }

        public static PaquetesTuristicodt listarxxx(int id)
        {
            SOIContext db = new SOIContext();

            var obj = db.PaquetesTuristicos
                .Select(b => new PaquetesTuristicodt()
                {
                    Id = b.Id,
                    PaqueteTuristico = b.PaqueteTuristico,
                    Descripcion = b.Descripcion,
                    Moneda = b.Moneda,
                    Simbolo = b.Simbolo,
                    PrecioUnitario = b.PrecioUnitario,
                    TiempoDuracion = b.TiempoDuracion,
                    UnidadDuracion = b.UnidadDuracion
                }).SingleOrDefault(b => b.Id == id);
            if (obj == null) obj = new PaquetesTuristicodt() { Id = 0, PaqueteTuristico = "" };
/*
            var sql = "select pt.*, ISNULL(fa.estado,0) estadofavorito from paquetes_turisticos pt left join favoritos fa on pt.id=fa.id_paquete_turistico and fa.id_usuario=" + idusu + " where pt.id_categoria=" + idcat + " and pt.id_pais=" + idpais;
            var paq = db.PaquetesTuristicos
                    .FromSqlRaw(sql)
                    .ToList();

            var lista = from b in db.PaquetesTuristicos
                        .FromSqlRaw(sql)
                        select new PaquetesTuristicodt()
                        {
                            Id = b.Id,
                            PaqueteTuristico = b.PaqueteTuristico,
                            Descripcion = b.Descripcion,
                            Moneda = b.Moneda,
                            Simbolo = b.Simbolo,
                            Preciounitario = b.PrecioUnitario,
                            TiempoDuracion = b.TiempoDuracion,
                            UnidadDuracion = b.UnidadDuracion,
                            EstadoFavorito = b.EstadoFavorito
                        };*/
            return obj;
        }
    }
}
