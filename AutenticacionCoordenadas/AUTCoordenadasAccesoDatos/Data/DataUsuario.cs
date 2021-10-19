using AUTCoordenadasAccesoADatos.Contexts;
using AUTCoordenadasEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AUTCoordenadasAccesoADatos.Data
{
    public class DataUsuario
    {
        private readonly BaseDContexts _context;

        public DataUsuario(BaseDContexts context)
        {
            _context = context;
        }

        public DataUsuario()
        {

            
        }


        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            return await _context.tb_Usuario.ToListAsync();
        }


        public async Task<String> RegistrarUsuario(Usuario usuarioRegistrar)
        {
            try
            {
                _context.tb_Usuario.Add(usuarioRegistrar);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                return "No se pueden guardar los cambios. " +
                       "Vuelve a intentarlo y, si el problema persiste, " +
                       "consulte con el administrador del sistema.";
            }
            return "Usuario registrado";
        }

        public async Task<String> ActualizarUsuario(int id, Usuario usuarioAct)
        {
            if (id != usuarioAct.Id)
            {
                return "Usuario no encontrado";
            }
            try
            {
                _context.tb_Usuario.Update(usuarioAct);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return "No se pueden guardar los cambios. " +
                    "Vuelve a intentarlo y, si el problema persiste, " +
                    "consulte con el administrador del sistema.";
            }
            return "Usuario actualizado";
        }

        public async Task<String> EliminarUsuario(int id)
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
                return "No se puede eliminar. " +
                     "Vuelve a intentarlo y, si el problema persiste, " +
                     "consulte con el administrador del sistema.";
            }
            return "Usuario eliminado con exito";
        }

    }
}
