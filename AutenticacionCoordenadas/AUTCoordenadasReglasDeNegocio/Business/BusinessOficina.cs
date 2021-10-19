using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AUTCoordenadasAccesoADatos.Data;
using AUTCoordenadasEntities.Entities;

namespace AUTCoordenadasReglasDeNegocio.Business
{
    public class BusinessOficina
    {
        private DataOficina oficina;

        public BusinessOficina(BaseDContexts _context)
        {
            oficina = new DataOficina();
        }


        public async Task<List<Oficina>> ObtenerOficinas()
        {
            return await oficina.ObtenerOficinas();
        }


        public async Task<String> RegistrarOficina(Oficina oficinaRegistrar)
        {
            return await oficina.RegistrarOficina(oficinaRegistrar);
        }


        public async Task<String> ActualizarOficina(int id, Oficina oficinaAct)
        {
            return await oficina.ActualizarOficina(id,oficinaAct);
        }


        public async Task<String> EliminarOficina(int id)
        {
            return await oficina.EliminarOficina(id);
        }

    }
}
   