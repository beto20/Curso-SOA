using GETYG.DTO;
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
    public class PaqueteTuristicoController : ControllerBase
    {
        /*
        
        http://localhost:35847/apiGYG/PaqueteTuristico/BuscarPaquetesTuristicos?_ubi=LI&_fechaida=10/11/2021&_fecharegreso=16/11/2021     
        http://localhost:35847/apiGYG/PaqueteTuristico/BuscarPaquetesTuristicos?_ubi=PERU    
        
        */
        [HttpGet("BuscarPaquetesTuristicos")]
        public List<DtoPaqueteTuristico> ListarPaquetesTuristicos(string _Ubi, string _fechaIda, string _fechaRegreso)
        {

            return PaquetesTuristico.ListarPaquetesTuristicos(_Ubi, Convert.ToDateTime(_fechaIda), Convert.ToDateTime(_fechaRegreso));
        }






    }
}
