using AUTCoordenadasEntities.Entities;
using AUTCoordenadasReglasDeNegocio.Business;
using AutenticacionCoordenadas.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace AutenticacionCoordenadas.Controllers
{
    public class UsuarioController : Controller
    {
        public IConfiguration Configuration { get; }

        HttpClient client = new HttpClient();
        const string SessionUser = "_User";
        const string SessionId = "_Id";
        public UsuarioController(IConfiguration configuration)
        {
            Configuration = configuration;
            //client.BaseAddress = new Uri("https://localhost:44333/");
            //client.BaseAddress = new Uri("https://localhost:5001/");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inicio()
        {
            ViewBag.Usuario = "";
            return View();
        }

        public IActionResult Autenticacion()
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

            ViewBag.Casilla1 = lista[0].ToString();
            ViewBag.Casilla2 = lista[1].ToString();
            ViewBag.Casilla3 = lista[2].ToString();
            ViewBag.Casilla4 = lista[3].ToString();

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

        [HttpPost]
        public async Task<IActionResult> SolicitarTarjeta()
        {

            Usuario usuario = new Usuario();
            usuario.Id = Int32.Parse(HttpContext.Session.GetString("_Id"));
            usuario.Observaciones = "Solicita tarjeta";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44333/Usuario/SolicitudTarjeta", usuario);

            return Json(new { status = true, message = "Listo" });
        }

        [HttpPost]
        public async Task<IActionResult> PeticionD()
        {
            Tarjeta datosTarjeta = new Tarjeta();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44333/Tarjeta/creacionTarjeta", datosTarjeta);
            return Json(new { status = true, message = "Realizado" });


        }

        [HttpPost]
        public async Task<IActionResult> BloqueoD()
        {

            Tarjeta datosTarjeta = new Tarjeta();
            datosTarjeta.id_usuario = 5;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44333/Tarjeta/creacionTarjeta", datosTarjeta);

            return Json(new { status = true, message = "creacion" });
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(BaseModel baseModel)
        {
            int salida = 1;
            Usuario usuario = new Usuario();
            usuario.usuario = baseModel.Usuario;
            usuario.Contrasena = baseModel.Contrasena;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44333/Usuario/IniciarSesion", usuario);
            //bool logrado = response.EnsureSuccessStatusCode().;
            // string resultado = businessUsuario.iniciarSesion(usuario);
            string resultado = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("Esta es la respuesta: " + resultado);
            string error = '"' + "NULL" + '"';
            if (resultado == error)
            {
                salida = 0;
            }
            if (salida == 0)
            {
                ViewBag.Usuario = "";
                return View("Inicio");
            }
            HttpContext.Session.Clear();
            HttpContext.Session.SetString(SessionUser, usuario.usuario);
            resultado = string.Join("", resultado.Split('"'));
            HttpContext.Session.SetString(SessionId, resultado);

            usuario.Id = Int32.Parse(resultado);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response2 = await client.PostAsJsonAsync(
                "https://localhost:44333/Usuario/EstadoTarjeta", usuario);

            string resultado2 = await response2.Content.ReadAsStringAsync();
            string error2 = '"' + "NULL" + '"';
            if (resultado2 == error2)
            {
                salida = 0;
            }
            if (salida == 0)
            {
                ViewBag.Usuario = "";
                return View("Peticion");
            }

            configurarParaAutenticacion();
            return View("Autenticacion");
        }

        [HttpPost]
        public IActionResult Autenticar(BaseModel baseModel)
        {

            ViewBag.Salida = "FALLO";
            int salida1 = validarCasilla(baseModel.FC1, baseModel.CA1).Result;
            int salida2 = validarCasilla(baseModel.FC2, baseModel.CA2).Result;
            int salida3 = validarCasilla(baseModel.FC3, baseModel.CA3).Result;
            int salida4 = validarCasilla(baseModel.FC4, baseModel.CA4).Result;
            int suma = 0;
            suma = salida1 + salida2 + salida3 + salida4;
            if (suma == 4)
            {
                ViewBag.Salida = "INGRESA";
            }
            return View("Salida");
        }

        public async Task<int> validarCasilla(string FilaColumna, string valor)
        {
            int salida = 1;

            string FilaCol = "";
            int cmpVal = valor[0].CompareTo('0');

            if (cmpVal == 0)
            {
                FilaCol = valor[1].ToString();
            }
            else
            {
                FilaCol = valor;
            }// else

            Tarjeta datosTarjeta = new Tarjeta();
            datosTarjeta.id = Int32.Parse(HttpContext.Session.GetString("_Id"));
            string filaColumna = FilaColumna;
            datosTarjeta.fila = Int32.Parse(filaColumna[1].ToString());
            datosTarjeta.columna = filaColumna[0].ToString();
            datosTarjeta.valor = Int32.Parse(FilaCol);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44333/Tarjeta/autenticar", datosTarjeta);
            string resultado = await response.Content.ReadAsStringAsync();


            Console.WriteLine(resultado);
            string error = '"' + "NULL" + '"';
            if (resultado == error)
            {
                salida = 0;
            }

            return salida;
        }

        public void configurarParaAutenticacion()
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

            ViewBag.Casilla1 = lista[0].ToString();
            ViewBag.Casilla2 = lista[1].ToString();
            ViewBag.Casilla3 = lista[2].ToString();
            ViewBag.Casilla4 = lista[3].ToString();
        }

    }

}