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
           System.Diagnostics.Debug.WriteLine("API User");
            return (new BusinessUsuario().iniciarSesion(datosUsuario));
           // return "NULL";
        }
        [HttpPost]
        public async Task<String> Registrar(Usuario usuario)
        {
            return await (new BusinessUsuario().Registrar(usuario)); ;
        }
        [HttpGet]
        [Route("ListaUsuarios")]
        public async Task<List<Usuario>> ListaUsuarios()
        {
            return await (new BusinessUsuario().ListaUsuarios()); ;
        }
        [HttpPost]
        public async Task<String> ActualizarUsuario(Usuario usuario)
        {
            return await (new BusinessUsuario().ActualizarUsuario(usuario));
        }
        [HttpPost]
        public async Task<String> EliminarUsuario(int id)
        {
            return await (new BusinessUsuario().EliminarUsuario(id));
        }
        [HttpPost]
        public async Task<List<Usuario>> BuscarUsuario(string nombre)
        {
            return await (new BusinessUsuario().BuscarUsuario(nombre));
        }
    }
}
