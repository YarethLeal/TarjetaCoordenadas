using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AUTCoordenadasAccesoADatos.Data;
using AUTCoordenadasEntities.Entities;
namespace AUTCoordenadasReglasDeNegocio.Business
{
    public class BusinessUsuario
    {
        private static DataUsuario _dUser = new DataUsuario();

        public async Task<String> Registrar(Usuario usuario)
        {
            return await _dUser.Registrar(usuario);
        }

        public async Task<List<Usuario>> ListaUsuarios()
        {
            return await _dUser.ListaUsuarios();
        }

        public async Task<String> ActualizarUsuario(int id, Usuario usuario)
        {
            return await _dUser.Actualizar(id, usuario);
        }

        public async Task<String> EliminarUsuario(int id)
        {
            return await _dUser.Eliminar(id);
        }

        public async Task<Usuario> BuscarUsuario(int id)
        {
            return await _dUser.Buscar(id);
        }
    }
}