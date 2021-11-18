using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUTCoordenadasEntities.Entities;
using AUTCoordenadasReglasDeNegocio.Business;


namespace AUTCoordenadasAPI.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class TarjetaController : ControllerBase
    {
        [HttpPost]
        [Route("autenticar")]
        public string autenticar(Tarjeta datosTarjeta)
        {
            if (datosTarjeta.valor.ToString().Length < 3)
            {
                System.Diagnostics.Debug.WriteLine("API User atenticar");
                return new BusinessTarjeta().autenticar(datosTarjeta);
                 
            }
            return "";
        }
        [HttpPost]
        [Route("creacionTarjeta")]
        public string creacionTarjeta(Tarjeta datosTarjeta)
        {
            return new BusinessTarjeta().creacionTarjeta(datosTarjeta);
        }
    }
}
