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
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace AutenticacionCoordenadas.Controllers
{
    public class UsuarioController : Controller
    {
        public IConfiguration Configuration { get; }
        private BusinessTarjeta businessTarjeta;
        private BusinessUsuario businessUsuario;

        public UsuarioController(IConfiguration configuration)
        {
            businessTarjeta = new BusinessTarjeta();
            businessUsuario = new BusinessUsuario();
            Configuration = configuration;
          
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
           int numero,letra;
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
        public IActionResult PeticionD()
        {
            Tarjeta datosTarjeta = new Tarjeta();
            businessTarjeta.creacionTarjeta(datosTarjeta);
            return Json(new { status = true, message = "Realizado" });
        }

        [HttpPost]
        public IActionResult BloqueoD()
        {

            Tarjeta datosTarjeta = new Tarjeta();
            datosTarjeta.id_usuario = 5;
            businessTarjeta.creacionTarjeta(datosTarjeta);

            return Json(new { status = true, message = "creacion" });
        }

        [HttpPost]
        public IActionResult IniciarSesion(BaseModel baseModel)
        {
            int salida = 1;
            Usuario usuario = new Usuario();
            usuario.usuario = baseModel.Usuario;
            usuario.Contrasena = baseModel.Contrasena;
            string resultado = businessUsuario.iniciarSesion(usuario);
            if (resultado == "NULL")
            {
                salida = 0;
            }
            /////
           if(salida==0)
            {
                ViewBag.Usuario = "";
                return View("Inicio");
            }

            configurarParaAutenticacion();
            return View("Autenticacion");
            //return Json(new { status = true, message = resultado});
        }

        [HttpPost]
        public IActionResult Autenticar(BaseModel baseModel)
        {
            
            ViewBag.Salida = "FALLO";
            int salida1 = validarCasilla(baseModel.FC1,baseModel.CA1);
            int salida2 = validarCasilla(baseModel.FC2, baseModel.CA2);
            int salida3 = validarCasilla(baseModel.FC3, baseModel.CA3);
            int salida4 = validarCasilla(baseModel.FC4, baseModel.CA4);
            int suma = 0;
            suma = salida1 + salida2 + salida3 + salida4;
            if (suma == 4)
            {
                ViewBag.Salida = "INGRESA";
            }
            return View("Salida");
        }

        public int validarCasilla(string FilaColumna, string valor)
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
            datosTarjeta.id = 12;
            string filaColumna = FilaColumna;
            datosTarjeta.fila = Int32.Parse(filaColumna[1].ToString());
            datosTarjeta.columna = filaColumna[0].ToString();
            datosTarjeta.valor = Int32.Parse(FilaCol);

            string resultado = businessTarjeta.autenticar(datosTarjeta);
            Console.WriteLine(resultado);
            if (resultado == "NULL")
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
