
using AUTCoordenadasAccesoADatos.Contexts;
using AUTCoordenadasEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AUTCoordenadasAccesoADatos.Data
{
    public class DataOficina
    {
              
        public async Task<List<Oficina>> ObtenerOficinas()
        {
            using (var _context = new BDContexts())
            {
                return await _context.tb_Oficina.ToListAsync();
            }
        }

        public async Task<Oficina> ObtenerOficina(int id)
        {
            using (var _context = new BDContexts())
            {
              return await _context.tb_Oficina.FindAsync(id);
            }
        }
        public async Task<String> RegistrarOficina(Oficina oficinaRegistrar)
        {
            try
            {
                using (var _context = new BDContexts())
                {
                    _context.tb_Oficina.Add(oficinaRegistrar);
                    await _context.SaveChangesAsync();

                }
            }
            catch (DbUpdateException /* ex */)
            {
                
              return "No se pueden guardar los cambios. " +
                       "Vuelve a intentarlo y, si el problema persiste, " +
                       "consulte con el administrador del sistema.";
            }
            return "Oficina Registrada";
            
        }

       
        public async Task<String> ActualizarOficina(int id, Oficina oficinaAct)
        {
            if (id != oficinaAct.Id)
            {
                return "Oficina no enconttrada";
            }

            try
            {
                using (var _context = new BDContexts())
                {
                    _context.Entry(oficinaAct).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException /* ex */)
            {
               
                return "No se pueden guardar los cambios. " +
                    "Vuelve a intentarlo y, si el problema persiste, " +
                    "consulte con el administrador del sistema.";
            }
            return "Oficina Actualizada";
           
        }


        public async Task<String> EliminarOficina(int id)
        {
            using (var _context = new BDContexts())
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

                }
                catch (DbUpdateException /* ex */)
                {
                    return "No se puede eliminar. " +
                         "Vuelve a intentarlo y, si el problema persiste, " +
                         "consulte con el administrador del sistema.";
                }
                return "Oficina Eliminada";
            }
        }

    }
}
