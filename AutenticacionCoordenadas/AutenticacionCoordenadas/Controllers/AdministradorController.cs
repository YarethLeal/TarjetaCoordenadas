using AUTCoordenadasReglasDeNegocio.Business;
using AUT
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUTCoordenadasAccesoADatos.Contexts;

namespace AutenticacionCoordenadas.Controllers
{
    public class AdministradorController : Controller
    {
        public IConfiguration Configuration { get; }
        private BusinessUsuario businessUsuario;
      
        public AdministradorController(IConfiguration configuration, BaseDContexts context)
        {
            businessUsuario = new BusinessUsuario(context);
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
