using GETYG.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GETYG.Controllers
{
    [Route("apiGYG/[controller]")]
    [ApiController]
    public class ValidacionCorreoController : ControllerBase
    {
        /*
        
        http://localhost:35847/apiGYG/ValidacionCorreo/ValidarCorreo?correo=correo1@gmail.com

        */
        [HttpGet("ValidarCorreo")]
        public string ValidarCorreo(string correo)
        {
            return Usuario.ValidarCorreo(correo);
        }


        /*
         
         http://localhost:35847/apiGYG/ValidacionCorreo/ActualizarEstadoCorreo?correo=correo2@gmail.com&estado=1

        */
        [HttpGet("ActualizarEstadoCorreo")]
        public string ActualizarEstadoCorreo(string correo, int estado)
        {
            return Usuario.ActualizarEstadoCorreo(correo, estado);
        }


    }
}
