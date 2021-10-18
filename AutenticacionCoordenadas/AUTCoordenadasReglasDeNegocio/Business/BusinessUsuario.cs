using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AUTCoordenadasAccesoADatos.Data;
using AUTCoordenadasAccesoADatos.Entities;

namespace AUTCoordenadasReglasDeNegocio.Business
{
    class BusinessUsuario
    {
        public DataUsuario _user;
        public BusinessUsuario()
        {
            _user = new DataUsuario();
        }

        public async Task<List<Usuario>> ListaUsuarios()
        {
            return await _user.ObtenerUsuarios();
        }

        public async Task<String> RegistrarUsuario(Usuario usuarioRegistrar)
        {
            return await _user.RegistrarUsuario(usuarioRegistrar);
        }

        public async Task<String> ActualizarUsuario(int id, Usuario usuarioAct)
        {
            return await _user.ActualizarUsuario(id,usuarioAct);
        }

        public async Task<String> EliminarUsuario(int id)
        {
            return await _user.EliminarUsuario(id);
        }
    }
}
