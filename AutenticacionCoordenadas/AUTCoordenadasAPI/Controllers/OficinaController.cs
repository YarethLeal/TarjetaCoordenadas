using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUTCoordenadasEntities.Entities;
using AUTCoordenadasReglasDeNegocio.Business;
using Microsoft.Extensions.Configuration;

namespace AUTCoordenadasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OficinaController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public OficinaController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        [Route("ObtenerOficinas")]
        public async Task<List<Oficina>> ObtenerOficinas()
        {
            return await (new BusinessOficina().ObtenerOficinas());
        }
        [HttpPost]
        public async Task<Oficina> ObtenerOficina(int id)
        {
            return await (new BusinessOficina().ObtenerOficina(id));

        }
        [HttpPost]
        public async Task<String> RegistrarOficina(Oficina oficinaRegistrar)
        {
            return await (new BusinessOficina().RegistrarOficina(oficinaRegistrar));
        }

        [HttpPost]
        public async Task<String> ActualizarOficina(int id, Oficina oficinaAct)
        {
            return await (new BusinessOficina().ActualizarOficina(id,oficinaAct));
        }

        [HttpPost]
        public async Task<String> EliminarOficina(int id)
        {
            return await (new BusinessOficina().EliminarOficina(id));
        }
    }
}
