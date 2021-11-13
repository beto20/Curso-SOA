using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.Transfer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [EnableCors("MyPolicyReniec")]
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilidadPaqueteTuristicoController : ControllerBase
    {
        [HttpGet("")]
        public string Get()
        {
            return "BIENBENIDO  <<<GUETYOURGUIDE>>>>";
        }
        [HttpGet("Search")]
        public IActionResult Search(string namelike)
        {
            var result = namelike;
            if (!result.Any())
            {
                return NotFound(namelike);
            }
            return Ok(result);
        }

        [HttpGet("VerInformacionGeneral")]
        public IEnumerable<PaquetesInformaciondt> VerInformacionGeneral(int id)
        {
            return PaquetesInformacion.VerInformacionGeneral(id);
        }

        [HttpGet("VerGaleriaFotos")]
        public IEnumerable<Galeriadt> VerGaleriaFotos(int id)
        {
            return Galeria.VerGaleriaFotos(id);
        }

        [HttpGet("VerPaqueteTuristico")]
        public PaquetesTuristicodt VerPaqueteTuristico(int id)
        {
            return PaquetesTuristico.VerPaqueteTuristico(id);
        }

        [HttpGet("ListarPaquetesSugeridos")]
        public IEnumerable<PaquetesTuristicodt> ListarPaquetesSugeridos(int idpais, int idcat)
        {
            return PaquetesTuristico.ListarPaquetesSugeridos(idpais, idcat);
        }

        [HttpGet("listarxxx")]
        public PaquetesTuristicodt listarxxx(int id)
        {
            return PaquetesTuristico.listarxxx(id);
        }

        [HttpGet("DisponibilidadPaqueteTuristico")]
        public DisponiblePaquetedt DisponibilidadPaqueteTuristico(int idp, DateTime fechareserva, int numper)
        {
            return PaquetesTuristico.DisponibilidadPaqueteTuristico(idp, fechareserva, numper);
        }
    }
}
