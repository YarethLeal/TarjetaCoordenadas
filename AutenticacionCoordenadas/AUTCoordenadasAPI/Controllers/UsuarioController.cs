using AUTCoordenadasEntities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUTCoordenadasReglasDeNegocio.Business;

namespace AUTCoordenadasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public string iniciarSesion(Usuario datosUsuario)
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
        [HttpPost]
        public async Task<List<Usuario>> ListaUsuarios()
        {
            return await (new BusinessUsuario().ListaUsuarios()); ;
        }
        [HttpPost]
        public async Task<String> ActualizarUsuario(int id, Usuario usuario)
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
