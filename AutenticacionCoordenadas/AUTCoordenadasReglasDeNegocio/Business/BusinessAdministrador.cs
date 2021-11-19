using AUTCoordenadasAccesoDatos.Data;
using AUTCoordenadasEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AUTCoordenadasReglasDeNegocio.Business
{
    public class BusinessAdministrador
    {
        private static DataMensaje _dMensaje = new DataMensaje();

        public string obtenerMensajes(Usuario datosUsuario)
        {
            return _dMensaje.obtenerMensajes(datosUsuario);
        }

        public string rechazarSolicitud(Mensaje datosMensaje)
        {
            return _dMensaje.rechazarSolicitud(datosMensaje);
        }

        public string aceptarSolicitud(Mensaje datosMensaje)
        {
            return _dMensaje.aceptarSolicitud(datosMensaje);
        }

    }
}