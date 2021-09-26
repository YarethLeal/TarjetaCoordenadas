using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutenticacionCoordenadas.Controllers
{
    public class UsuarioController : Controller
    {
        public IConfiguration Configuration { get; }

        public UsuarioController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Autenticacion()
        {
            return View();
        }

        public IActionResult Bloqueo()
        {
            return View();
        }

        public IActionResult Notificacion()
        {
            return View();
        }

        public IActionResult Peticion()
        {
            return View();
        }

    }
}
