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
        public string CA1 { get; set; }
        public string CA2 { get; set; }
        public string CA3 { get; set; }
        public string CA4 { get; set; }
        public string FC1 { get; set; }
        public string FC2 { get; set; }
        public string FC3 { get; set; }
        public string FC4 { get; set; }
    }
}
