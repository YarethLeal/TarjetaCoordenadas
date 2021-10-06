using AutenticacionCoordenadas.Contexts;
using AutenticacionCoordenadas.Models;
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
        private readonly BDContexts _context;

        //public AdministradorController(BDContexts context)
        //{
        //    _context = context;
        //}
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

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ObtenerUsuarios()
        {
            return await _context.tb_Usuario.ToListAsync();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarUsuario(Usuario usuarioRegistrar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.tb_Usuario.Add(usuarioRegistrar);
                    await _context.SaveChangesAsync();
                   // return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "No se pueden guardar los cambios. " +
                       "Vuelve a intentarlo y, si el problema persiste, " +
                       "consulte con el administrador del sistema.");
            }
            return Ok();
            //return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarUsuario(int id, Usuario usuarioAct)
        {
            if (id != usuarioAct.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.tb_Usuario.Update(usuarioAct);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "No se pueden guardar los cambios. " +
                        "Vuelve a intentarlo y, si el problema persiste, " +
                        "consulte con el administrador del sistema.");
                }
            }
            return Ok();
            //return View(usuarioAct);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var usuario = await _context.tb_Usuario.FindAsync(id);
            if (usuario == null)
            {
               // return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.tb_Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "No se puede eliminar. " +
                     "Vuelve a intentarlo y, si el problema persiste, " +
                     "consulte con el administrador del sistema.");
            }
            return Ok();
        }

        //Oficina

        [HttpGet]
        public async Task<ActionResult<List<Oficina>>> ObtenerOficinas()
        {
            return await _context.tb_Oficina.ToListAsync();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarOficina(Oficina oficinaRegistrar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.tb_Oficina.Add(oficinaRegistrar);
                    await _context.SaveChangesAsync();
                    // return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "No se pueden guardar los cambios. " +
                       "Vuelve a intentarlo y, si el problema persiste, " +
                       "consulte con el administrador del sistema.");
            }
            return Ok();
            //return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarOficina(int id, Oficina oficinaAct)
        {
            if (id != oficinaAct.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.tb_Oficina.Update(oficinaAct);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "No se pueden guardar los cambios. " +
                        "Vuelve a intentarlo y, si el problema persiste, " +
                        "consulte con el administrador del sistema.");
                }
            }
            return Ok();
            //return View(usuarioAct);
        }

        [HttpPost, ActionName("DeleteOffice")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarOficina(int id)
        {
            var oficina = await _context.tb_Oficina.FindAsync(id);
            if (oficina == null)
            {
                // return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.tb_Oficina.Remove(oficina);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "No se puede eliminar. " +
                     "Vuelve a intentarlo y, si el problema persiste, " +
                     "consulte con el administrador del sistema.");
            }
            return Ok();
        }

    }
}
