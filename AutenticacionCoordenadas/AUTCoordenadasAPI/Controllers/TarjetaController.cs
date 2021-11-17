using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUTCoordenadasEntities.Entities;
using AUTCoordenadasReglasDeNegocio.Business;


namespace AUTCoordenadasAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        [HttpPost]
        public string autenticar(Tarjeta datosTarjeta)
        {
            if (datosTarjeta.valor.ToString().Length < 3)
            {
                return new BusinessTarjeta().autenticar(datosTarjeta);
                 
            }
            return "";
        }
        [HttpPost]
        public string creacionTarjeta(Tarjeta datosTarjeta)
        {
            return new BusinessTarjeta().creacionTarjeta(datosTarjeta);
        }
    }
}
