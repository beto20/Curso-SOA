using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETYG.Models
{
    public partial class Usuario
    {

        public static string ValidarCorreo(string _correo)
        {
            GYGContext db = new GYGContext();
            var usu = db.Usuarios.Where(x => x.Correo == _correo && x.IbCorreoValido == true).ToList();
            
            if (usu != null)
            {
                if (usu.Count != 0)
                    return "Correo validado";
                else
                    return "Correo no validado";
            }
            else
                return "Correo no validado";
        }

        public static string ActualizarEstadoCorreo(string _correo, int _estado)
        {
            GYGContext db = new GYGContext();
            Usuario _usu = ObtenerUsuario(_correo);
            if (_usu.Id != 0)
            {
                _usu.IbCorreoValido = _estado == 1 ? true : false;
                db.Entry(_usu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Usuario.ValidarCorreo(_correo);
        }

        private static Usuario ObtenerUsuario(string _correo)
        {
            GYGContext db = new GYGContext();
            Usuario _usu = db.Usuarios.Select(u => new Usuario()
            {
                Id = u.Id,
                Correo = u.Correo
            }).SingleOrDefault(b => b.Correo == _correo);

            if (_usu.Id != 0)
                return db.Usuarios.Find(_usu.Id);
            else
                return new Usuario();
        }

    }
}
