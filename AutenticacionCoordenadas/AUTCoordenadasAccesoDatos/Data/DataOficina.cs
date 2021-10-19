
using AUTCoordenadasAccesoADatos.Contexts;
using AUTCoordenadasEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AUTCoordenadasAccesoADatos.Data
{
    public class DataOficina
    {
        private readonly BaseDContexts _context;

        public DataOficina(BaseDContexts context)
        {
            _context = context;
        }
        public DataOficina()
        {
          
        }


        public async Task<List<Oficina>> ObtenerOficinas()
        {
            return await _context.tb_Oficina.ToListAsync();
        }


        public async Task<String> RegistrarOficina(Oficina oficinaRegistrar)
        {
            try
            {
                   _context.tb_Oficina.Add(oficinaRegistrar);
                    await _context.SaveChangesAsync();

                
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
                _context.tb_Oficina.Update(oficinaAct);
                await _context.SaveChangesAsync();
                
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
