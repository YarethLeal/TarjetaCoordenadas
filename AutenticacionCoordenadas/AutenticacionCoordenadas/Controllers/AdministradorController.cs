using AUTCoordenadasEntities.Entities;
using AUTCoordenadasReglasDeNegocio.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace AutenticacionCoordenadas.Controllers
{
    public class AdministradorController : Controller
    {
        BusinessTarjeta businessTarjeta;
        public IConfiguration Configuration { get; }
        HttpClient client = new HttpClient();
        public AdministradorController(IConfiguration configuration)
        {
             Configuration = configuration;
            businessTarjeta = new BusinessTarjeta();
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Actualiza(int IdEdit)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("https://localhost:44333/Usuario/BuscarId/" + IdEdit);
            string resultado = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(resultado);
            
            ViewBag.Usuario = usuario;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Actualizar(Usuario usuarioParam)
        {
            
            usuarioParam.FechaActualiza = DateTime.Today;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44333/Usuario/ActualizarUsuario", usuarioParam);
            return Redirect("~/Administrador/Buscar");
        }


        public async Task<IActionResult> Buscar()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(
                "https://localhost:44333/Usuario/ListaUsuarios");

            var model = JsonConvert.DeserializeObject<List<Usuario>>(response.Content.ReadAsStringAsync().Result);
            

            return View("Buscar",model);
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuscarUsuarioNombre(string nombre)
        {

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("https://localhost:44333/Usuario/BuscarUsuario/" + nombre);
            string resultado = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<List<Usuario>>(resultado);
                      
            return View("Buscar",model);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarUsuario(int IdDelete)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44333/Usuario/EliminarUsuario", IdDelete);
            ViewBag.respuesta = JsonConvert.DeserializeObject<String>(response.Content.ReadAsStringAsync().Result);


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response1 = await client.GetAsync(
                "https://localhost:44333/Usuario/ListaUsuarios");
            var model = JsonConvert.DeserializeObject<List<Usuario>>(response1.Content.ReadAsStringAsync().Result);
            return View("Buscar", model);
        }


        [HttpPost]
        public async Task<IActionResult> Registro(Usuario usuarioParam)
        {

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44333/Usuario/Registrar", usuarioParam);
            ViewBag.respuesta = JsonConvert.DeserializeObject<String>(response.Content.ReadAsStringAsync().Result);
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

        public IActionResult Reportes()
        {
            List<SelectListItem> acciones = new List<SelectListItem>();
            acciones.Add(new SelectListItem { Text = "Aceptar solicitud desbloqueo", Value = "Aceptar solicitud desbloqueo" });
            acciones.Add(new SelectListItem { Text = "Aceptar solicitud tarjeta", Value = "Aceptar solicitud tarjeta" });
            acciones.Add(new SelectListItem { Text = "Rechazo solicitud tarjeta", Value = "Rechazo solicitud tarjeta" });

            ViewBag.Acciones = acciones;

            return View();
        }

        [HttpPost]
        public IActionResult Reporte1(BaseModel baseModel)
        {
            string info = "";
            if (baseModel.usuario == "Usuario administrador")
            { // si esta como se definio, se considera que quiere buscar por fecha
                if (baseModel.accion == "Aceptar solicitud desbloqueo")
                {
                    info = businessTarjeta.obtenerTarjetasDesbloqueadasPorFecha(baseModel.FechaInicio.Date.ToShortDateString(), baseModel.FechaFin.Date.ToShortDateString());
                }
                else if (baseModel.accion == "Aceptar solicitud tarjeta")
                {
                    info = businessTarjeta.obtenerTarjetasEntregadasPorFecha(baseModel.FechaInicio.Date.ToShortDateString(), baseModel.FechaFin.Date.ToShortDateString());
                }
                else
                {
                    info = businessTarjeta.obtenerTarjetasNegadasPorFecha(baseModel.FechaInicio.Date.ToShortDateString(), baseModel.FechaFin.Date.ToShortDateString());
                }// else
            }
            else
            {
                if (baseModel.accion == "Aceptar solicitud desbloqueo")
                {
                    info = businessTarjeta.obtenerTarjetasDesbloqueadasPorAdministrador(baseModel.usuario);
                }
                else if (baseModel.accion == "Aceptar solicitud tarjeta")
                {
                    info = businessTarjeta.obtenerTarjetasEntregadasPorAdministrador(baseModel.usuario);
                }
                else
                {
                    info = businessTarjeta.obtenerTarjetasNegadasPorAdministrador(baseModel.usuario);
                }// else
            }//

                return Json(new { status = true, message = info });
            }


        }
}
