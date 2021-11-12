using System;
using System.Collections.Generic;
using System.Text;

namespace AUTCoordenadasEntities.Entities
{
    public class Tarjeta
    {
        public int id_usuario { get; set; }
        public int id_tarjeta { get; set; }
        public string estado { get; set; }
        public int id { get; set; }
        public int fila { get; set; }
        public string columna { get; set; }
        public int valor { get; set; }

    }
}
