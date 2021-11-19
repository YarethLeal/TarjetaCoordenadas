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

        public string iniciarSesion(Usuario datosUsuario)
        {
            return _dUser.iniciarSesion(datosUsuario);
        }

        public string estadoTarjeta(Usuario datosUsuario)
        {
            return _dUser.estadoTarjeta(datosUsuario);
        }

        public string solicitudTarjeta(Usuario datosUsuario)
        {
            return _dUser.solicitudTarjeta(datosUsuario);
        }

        public async Task<String> Registrar(Usuario usuario)
        {
            return await _dUser.Registrar(usuario);
        }

        public async Task<List<Usuario>> ListaUsuarios()
        {
            return await _dUser.ListaUsuarios();
        }

        public async Task<String> ActualizarUsuario(Usuario usuario)
        {
            return await _dUser.Actualizar(usuario);
        }

        public async Task<String> EliminarUsuario(int id)
        {
            return await _dUser.Eliminar(id);
        }

        public async Task<List<Usuario>> BuscarUsuario(string nombre)
        {
            return await _dUser.BuscarNombre(nombre);
        }

        public async Task<Usuario> BuscarId(int id)
        {
            return await _dUser.BuscarId(id);
        }
    }
}