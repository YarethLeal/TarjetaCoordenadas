using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AUTCoordenadasAccesoADatos.Entities
{
    public class Oficina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }
        public string Usuario { get; set; }
        public char CodigoOficina { get; set; }
        public bool Estado { get; set; }
        public int Institucion { get; set; }

    }


}
