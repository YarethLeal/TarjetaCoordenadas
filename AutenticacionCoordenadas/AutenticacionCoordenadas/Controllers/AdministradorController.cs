using AutenticacionCoordenadas.Contexts;
using Microsoft.AspNetCore.Mvc;
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
        private readonly BDContexts _context;

        public AdministradorController(BDContexts context)
        {
            _context = context;
        }
        public AdministradorController(IConfiguration configuration)
        {
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
        //// GET: /<ValuesController>
        //[HttpGet]
        //public IEnumerable<Usuario> Get()
        //{
        //    //return new String[] {"hola", "todos" };
        //  return context.TB_USUARIO.ToList();
        //}

        //// GET /<ValuesController>/5
        //[HttpGet("{cedula}")]
        //public Usuario Get(int cedula)
        //{
        //    var usuario = context.TB_USUARIO.FirstOrDefault(u=> u.cedula == cedula);
        //    return usuario;
        //}

        //// POST /<ValuesController> 'ingresos'
        //[HttpPost]
        //public ActionResult Post([FromBody] Usuario usuario)
        //{
        //    try {
        //        context.TB_USUARIO.Add(usuario);
        //        context.SaveChanges();
        //        return Ok();
        //    }
        //    catch (Exception ex) 
        //    {
        //        return BadRequest();
        //    }
        //}

        //// PUT (Actulizar) /<ValuesController>/5
        //[HttpPut("{cedula}")]
        //public ActionResult Put(int cedula, [FromBody] Usuario usuario)
        //{
        //    if (usuario.cedula == cedula)
        //    {
        //        context.Entry(usuario).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return Ok();
        //    }
        //    else 
        //    {
        //        return BadRequest();
        //    }
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{cedula}")]
        //public ActionResult Delete(int cedula)
        //{
        //    var usuario = context.TB_USUARIO.FirstOrDefault(u => u.cedula == cedula);
        //    if (usuario != null)
        //    {
        //        context.TB_USUARIO.Remove(usuario);
        //        context.SaveChanges();
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
