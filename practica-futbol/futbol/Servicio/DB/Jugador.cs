using System;
using System.Collections.Generic;

#nullable disable

namespace Servicio.DB
{
    public partial class Jugador
    {
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double Peso { get; set; }
        public int Edad { get; set; }
        public int IdEquipo { get; set; }

        public virtual Equipo IdEquipoNavigation { get; set; }
    }
}
