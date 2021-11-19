using AUTCoordenadasEntities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUTCoordenadasReglasDeNegocio.Business;
using Microsoft.Extensions.Configuration;

namespace AUTCoordenadasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public UsuarioController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public string IniciarSesion(Usuario datosUsuario)
        {

            return (new BusinessUsuario().iniciarSesion(datosUsuario));
            // return "NULL";
        }// iniciar sesion

        [HttpPost]
        [Route("EstadoTarjeta")]
        public string EstadoTarjeta(Usuario datosUsuario)
        {

            return (new BusinessUsuario().estadoTarjeta(datosUsuario));
            // return "NULL";
        }// estado tarjeta

        [HttpPost]
        [Route("SolicitudTarjeta")]
        public string SolicitudTarjeta(Usuario datosUsuario)
        {

            return (new BusinessUsuario().solicitudTarjeta(datosUsuario));
            // return "NULL";
        }// solicitud tarjeta

        [HttpPost]
        [Route("Registrar")]
        public async Task<String> Registrar(Usuario usuario)
        {
            usuario.FechaActualiza = DateTime.Today;
            usuario.Observaciones = "ninguna";
            usuario.UsuarioActualiza = "admin";
            usuario.CantidadIntentosAcceso = 0;
            return await (new BusinessUsuario().Registrar(usuario)); ;
        }
        [HttpGet]
        [Route("ListaUsuarios")]
        public async Task<List<Usuario>> ListaUsuarios()
        {
            return await (new BusinessUsuario().ListaUsuarios()); ;
        }

        [HttpPut]
        [Route("ActualizarUsuario")]
        public async Task<String> ActualizarUsuario(Usuario usuario)
        {
            return await (new BusinessUsuario().ActualizarUsuario(usuario));
        }

        [HttpPost]
        [Route("EliminarUsuario")]
        public async Task<String> EliminarUsuario(int id)
        {
            return await (new BusinessUsuario().EliminarUsuario(id));
        }

        [HttpGet]
        [Route("BuscarUsuario/{nombre}")]
        public async Task<List<Usuario>> BuscarUsuario(string nombre)
        {
            return await (new BusinessUsuario().BuscarUsuario(nombre));
        }

        [HttpGet]
        [Route("BuscarId/{IdEdit}")]
        public async Task<Usuario> BuscarId(int IdEdit)
        {
            return await (new BusinessUsuario().BuscarId(IdEdit));
        }
    }
}