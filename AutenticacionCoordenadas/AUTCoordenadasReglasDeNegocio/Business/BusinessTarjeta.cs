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

        public string creacionTarjeta(Tarjeta datosTarjeta)
        {
            return dataTarjeta.creacionTarjeta(datosTarjeta);
        }

    }
}
