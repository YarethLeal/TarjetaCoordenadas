using AUTCoordenadasEntities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUTCoordenadasReglasDeNegocio.Business;
using Microsoft.Extensions.Configuration;
using System.Collections;

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
        [Route("ContarIntento")]
        public string ContarIntento(Usuario datosUsuario)
        {
            return (new BusinessUsuario().contarIntento(datosUsuario));
            // return "NULL";
        }// estado tarjeta

        [HttpPost]
        [Route("LimpiarIntentos")]
        public string LimpiarIntentos(Usuario datosUsuario)
        {
            return (new BusinessUsuario().limpiarIntentos(datosUsuario));
            // return "NULL";
        }// estado tarjeta

        [HttpPost]
        [Route("BloquearTarjeta")]
        public string BloquearTarjeta(Tarjeta tarjeta)
        {
            return (new BusinessTarjeta().bloquearTarjeta(tarjeta));
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
        [Route("DatosAutenticar")]
        public string DatosAutenticar(Usuario datosUsuario)
        {
            // el usuario tiene tarjeta?
            string estado=(new BusinessUsuario().estadoTarjeta(datosUsuario));
            if (String.Equals(estado, "A"))
            {
                var rand = new Random();
                ArrayList lista = new ArrayList();
                int numero, letra;
                string salida = "";
                for (int i = 0; i < 4; i++)
                {
                    do
                    {
                        numero = rand.Next(1, 5);
                        letra = rand.Next(65, 74); // 5,6,7,8,9,0,1,2,3,4
                        string letraS = ((char)letra).ToString();
                        string numS = numero.ToString();
                        salida = letraS + numS;
                    } while (lista.Contains(salida));
                    lista.Add(salida);

                }

                string valores = "";
                valores += lista[0].ToString();
                valores += "-";
                valores += lista[1].ToString();
                valores += "-";
                valores += lista[2].ToString();
                valores += "-";
                valores += lista[3].ToString();

                estado = valores;
            }
            else if (String.Equals(estado, "B"))
            {
                estado = "Su tarjeta esta bloqueada";
            }
            else
            {
                estado = "Solicite una tarjeta en el sistema";
            }// else


            return estado;
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

        [HttpPost]
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