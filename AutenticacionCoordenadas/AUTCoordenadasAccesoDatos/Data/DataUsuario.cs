using System;
using System.Collections.Generic;
using System.Text;

namespace AUTCoordenadasAccesoADatos.Data
{
    class DataUsuario
    {
        //private readonly BDContexts _context;

        //public DataUsuario(BDContexts context)
        //{
        //    _context = context;
        //}


        //[HttpGet]
        //public async Task<ActionResult<List<Usuario>>> ObtenerUsuarios()
        //{
        //    return await _context.tb_Usuario.ToListAsync();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> RegistrarUsuario(Usuario usuarioRegistrar)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.tb_Usuario.Add(usuarioRegistrar);
        //            await _context.SaveChangesAsync();
        //            // return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    catch (DbUpdateException /* ex */)
        //    {
        //        //Log the error (uncomment ex variable name and write a log.
        //        ModelState.AddModelError("", "No se pueden guardar los cambios. " +
        //               "Vuelve a intentarlo y, si el problema persiste, " +
        //               "consulte con el administrador del sistema.");
        //    }
        //    return Ok();
        //    //return View(usuario);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ActualizarUsuario(int id, Usuario usuarioAct)
        //{
        //    if (id != usuarioAct.Id)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.tb_Usuario.Update(usuarioAct);
        //            await _context.SaveChangesAsync();
        //            //return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbUpdateException /* ex */)
        //        {
        //            //Log the error (uncomment ex variable name and write a log.)
        //            ModelState.AddModelError("", "No se pueden guardar los cambios. " +
        //                "Vuelve a intentarlo y, si el problema persiste, " +
        //                "consulte con el administrador del sistema.");
        //        }
        //    }
        //    return Ok();
        //    //return View(usuarioAct);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EliminarUsuario(int id)
        //{
        //    var usuario = await _context.tb_Usuario.FindAsync(id);
        //    if (usuario == null)
        //    {
        //        // return RedirectToAction(nameof(Index));
        //    }

        //    try
        //    {
        //        _context.tb_Usuario.Remove(usuario);
        //        await _context.SaveChangesAsync();
        //        //return RedirectToAction(nameof(Index));
        //    }
        //    catch (DbUpdateException /* ex */)
        //    {
        //        //Log the error (uncomment ex variable name and write a log.)
        //        ModelState.AddModelError("", "No se puede eliminar. " +
        //             "Vuelve a intentarlo y, si el problema persiste, " +
        //             "consulte con el administrador del sistema.");
        //    }
        //    return Ok();
        //}

    }
}
