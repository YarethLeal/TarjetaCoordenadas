using AUTCoordenadasEntities.Entities;
using AUTCoordenadasReglasDeNegocio.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AUTCoordenadasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministradorController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public AdministradorController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        [Route("ObtenerMensajes")]
        public string ObtenerMensajes(Usuario datosUsuario)
        {

            return (new BusinessAdministrador().obtenerMensajes(datosUsuario));
            // return "NULL";
        }// iniciar sesion

        [HttpPost]
        [Route("RechazarSolicitud")]
        public string RechazarSolictud(Mensaje mensaje)
        {

            return (new BusinessAdministrador().rechazarSolicitud(mensaje));
            // return "NULL";
        }// iniciar sesion

        [HttpPost]
        [Route("AceptarSolicitud")]
        public string AceptarSolictud(Mensaje mensaje)
        {

            return (new BusinessAdministrador().aceptarSolicitud(mensaje));
            // return "NULL";
        }// iniciar sesion

        [HttpPost]
        [Route("CreacionTarjeta")]
        public string CreacionTarjeta(Tarjeta tarjeta)
        {

            return (new BusinessTarjeta().creacionTarjeta(tarjeta));
            // return "NULL";
        }// iniciar sesion

    }
}

