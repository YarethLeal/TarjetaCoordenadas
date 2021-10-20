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

        public IActionResult Buscar()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Usuario usuario)
        {
            usuario.NombreUsuario = "Ara";
            usuario.Correo = "Arasaen";
            await businessUsuario.RegistrarUsuario(usuario);
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
