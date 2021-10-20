using AUTCoordenadasAccesoADatos.Contexts;
using AUTCoordenadasEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AUTCoordenadasAccesoADatos.Data
{
    public class DataUsuario
    {
        public async Task<String> Registrar(Usuario usuario)
        {
            try
            {
                using (var _context = new BDContexts())
                {
                    _context.tb_Usuario.Add(usuario);
                    await _context.SaveChangesAsync();
                }
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
        public async Task<List<Usuario>> ListaUsuarios()
        {
            using (var _context = new BDContexts())
            {
                return await _context.tb_Usuario.ToListAsync();
            }
        }

        public async Task<String> Actualizar(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return "Usuario no encontrado";
            }
            try
            {
                using (var _context = new BDContexts())
                {
                    _context.Entry(usuario).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
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

        public async Task<String> Eliminar(int id)
        {
            using (var _context = new BDContexts())
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
            }
            return "Usuario eliminado con exito";
        }

        public async Task<Usuario> Buscar(int id)
        {
            using (var _context = new BDContexts())
            {
                var usuario = await _context.tb_Usuario.FindAsync(id);
                if (usuario == null)
                {
                    return null;
                }
                return usuario;
            }
        }
    }
}
