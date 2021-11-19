using System;
using System.Collections.Generic;
using System.Text;

namespace AUTCoordenadasEntities.Entities
{
    public class Mensaje
    {

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string accion { get; set; }
        public string usuario { get; set; }
        public string administrador { get; set; }
        public string motivo { get; set; }
        public string fecha { get; set; }
        public int idUsuario { get; set; }

    }
}