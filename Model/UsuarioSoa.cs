using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Transfer;

namespace WebApi.Model
{
    public partial class Usuario
    {
        public static Usuariodt InicioSession(string email, string clave)
        {
            SOIContext db = new SOIContext();

            var obj = db.Usuarios
                      .Where(b=> b.Correo == email && b.Password == clave)
                      .Select(b=> new Usuariodt(){
                          Id = b.Id,
                          Correo = b.Correo,
                          FechaUltimaIngreso = b.FechaUltimaIngreso
                      }).SingleOrDefault();

            if (obj == null) obj = new Usuariodt() { Id=0 };
            return obj;
        }
        public static List<KeyValuePair<String, String>> InicioSession_1(string email, string clave)
        {
            SOIContext db = new SOIContext();

            var Lista = new List<KeyValuePair<String, String>> {
                  new KeyValuePair<String, String>("msn", "Error")
                 };
            if (db.Usuarios.First(t => t.Correo == email && t.Password == clave) != null)
            {
                var rta = db.Usuarios.First(t => t.Correo == email && t.Password == clave);
                var List = new List<KeyValuePair<String, String>> {
                  new KeyValuePair<String, String>("id", rta.Id.ToString()),
                  new KeyValuePair<String, String>("correo" , rta.Correo),
                 };
                Lista = List;
            }
            return Lista;
        }
    }
}
