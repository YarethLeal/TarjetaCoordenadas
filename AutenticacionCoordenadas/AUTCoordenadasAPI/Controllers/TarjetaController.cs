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
        public string obtenerTarjetasEntregadasPorFecha(string fechaI, string fechaF)
        {
            return new BusinessTarjeta().obtenerTarjetasEntregadasPorFecha(fechaI, fechaF);
        }

        public string obtenerTarjetasNegadasPorFecha(string fechaI, string fechaF)
        {
            return new BusinessTarjeta().obtenerTarjetasNegadasPorFecha(fechaI, fechaF);
        }

        public string obtenerTarjetasDesbloqueadasPorFecha(string fechaI, string fechaF)
        {
            return new BusinessTarjeta().obtenerTarjetasDesbloqueadasPorFecha(fechaI, fechaF);
        }

        public string obtenerTarjetasDesbloqueadasPorAdministrador(string administrador)
        {
            return new BusinessTarjeta().obtenerTarjetasDesbloqueadasPorAdministrador(administrador);
        }

        public string obtenerTarjetasNegadasPorAdministrador(string administrador)
        {
            return new BusinessTarjeta().obtenerTarjetasNegadasPorAdministrador(administrador);
        }

        public string obtenerTarjetasEntregadasPorAdministrador(string administrador)
        {
            return new BusinessTarjeta().obtenerTarjetasEntregadasPorAdministrador(administrador);
        }
    }
}
