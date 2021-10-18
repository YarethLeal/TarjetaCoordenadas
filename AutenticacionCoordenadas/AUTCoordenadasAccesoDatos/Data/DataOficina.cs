
using System;
using System.Collections.Generic;
using System.Text;

namespace AUTCoordenadasAccesoADatos.Data
{
    class DataOficina
    {
        //private readonly BDContexts _context;

        //public DataOficina(BDContexts context)
        //{
        //    _context = context;
        //}



        ////Oficina

        //[HttpGet]
        //public async Task<ActionResult<List<Oficina>>> ObtenerOficinas()
        //{
        //    return await _context.tb_Oficina.ToListAsync();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> RegistrarOficina(Oficina oficinaRegistrar)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.tb_Oficina.Add(oficinaRegistrar);
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
        //public async Task<IActionResult> ActualizarOficina(int id, Oficina oficinaAct)
        //{
        //    if (id != oficinaAct.Id)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.tb_Oficina.Update(oficinaAct);
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

        //[HttpPost, ActionName("DeleteOffice")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EliminarOficina(int id)
        //{
        //    var oficina = await _context.tb_Oficina.FindAsync(id);
        //    if (oficina == null)
        //    {
        //        // return RedirectToAction(nameof(Index));
        //    }

        //    try
        //    {
        //        _context.tb_Oficina.Remove(oficina);
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
