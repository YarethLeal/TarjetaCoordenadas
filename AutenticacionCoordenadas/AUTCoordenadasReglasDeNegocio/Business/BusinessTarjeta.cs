using AUTCoordenadasAccesoDatos.Data;
using AUTCoordenadasEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AUTCoordenadasReglasDeNegocio.Business
{
    public class BusinessTarjeta
    {
        private static DataTarjeta dataTarjeta = new DataTarjeta();

        public string autenticar(Tarjeta datosTarjeta)
        {
            return dataTarjeta.autenticar(datosTarjeta);
        }

        public string desbloquearTarjeta(Tarjeta datosTarjeta)
        {
            return dataTarjeta.desbloquearTarjeta(datosTarjeta);
        }// desbloquear

        public string bloquearTarjeta(Tarjeta datosTarjeta)
        {
            return dataTarjeta.bloquearTarjeta(datosTarjeta);
        }// bloquear

        public string creacionTarjeta(Tarjeta datosTarjeta)
        {
            return dataTarjeta.creacionTarjeta(datosTarjeta);
        }

        public string obtenerTarjetasEntregadasPorFecha(string fechaI, string fechaF)
        {
            return dataTarjeta.obtenerTarjetasEntregadasPorFecha(fechaI, fechaF);
        }

        public string obtenerTarjetasNegadasPorFecha(string fechaI, string fechaF)
        {
            return dataTarjeta.obtenerTarjetasNegadasPorFecha(fechaI, fechaF);
        }

        public string obtenerTarjetasDesbloqueadasPorFecha(string fechaI, string fechaF)
        {
            return dataTarjeta.obtenerTarjetasNegadasPorFecha(fechaI, fechaF);
        }

        public string obtenerTarjetasDesbloqueadasPorAdministrador(string administrador)
        {
            return dataTarjeta.obtenerTarjetasDesbloqueadasPorAdministrador(administrador);
        }

        public string obtenerTarjetasNegadasPorAdministrador(string administrador)
        {
            return dataTarjeta.obtenerTarjetasNegadasPorAdministrador(administrador);
        }

        public string obtenerTarjetasEntregadasPorAdministrador(string administrador)
        {
            return dataTarjeta.obtenerTarjetasEntregadasPorAdministrador(administrador);
        }

    }
}
