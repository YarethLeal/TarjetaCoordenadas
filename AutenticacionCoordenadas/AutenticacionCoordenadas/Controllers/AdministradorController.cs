using AUTCoordenadasEntities.Entities;
using AUTCoordenadasReglasDeNegocio.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AutenticacionCoordenadas.Controllers
{
    public class AdministradorController : Controller
    {
        public IConfiguration Configuration { get; }
        private BusinessUsuario businessUsuario;
        private BusinessOficina businessOficina;

      
        public AdministradorController(IConfiguration configuration)
        {
            businessUsuario = new BusinessUsuario();
            businessOficina = new BusinessOficina();
            Configuration = configuration;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Actualiza()
        {
            return View();
        }

        public async Task<IActionResult> Buscar()


        {

            var model = await businessUsuario.ListaUsuarios();
            return View(model);
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuscarUsuarioNombre(string nombre)
        {

            var model = await businessUsuario.BuscarUsuario(nombre);

            return View("Buscar",model);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarUsuario(int id)
        {

            var result = await businessUsuario.EliminarUsuario(id);
            var model = await businessUsuario.ListaUsuarios();
            return View("Buscar", model);
        }


        [HttpPost]
        public async Task<IActionResult> Registro(Usuario usuarioParam)
        {
            System.Diagnostics.Debug.WriteLine("Debug Controlador");
            System.Diagnostics.Debug.WriteLine(usuarioParam.OficinaID);
            usuarioParam.FechaActualiza = DateTime.Today;
            usuarioParam.Observaciones = "ninguna";
            usuarioParam.UsuarioActualiza = "admin";
            usuarioParam.CantidadIntentosAcceso = 1;
            usuarioParam.TipoUsuario = 'u';
            await businessUsuario.Registrar(usuarioParam);
            return View();
        }

        public IActionResult Solicitud()
        {
            return View();
        }

        public IActionResult ActualizaOficina()
        {
            return View();
        }

        public IActionResult BuscarOficina()
        {
            return View();
        }

        public IActionResult RegistroOficina()
        {

            return View();
        }

    }
}
