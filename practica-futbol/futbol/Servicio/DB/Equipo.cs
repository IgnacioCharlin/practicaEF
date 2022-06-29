using System;
using System.Collections.Generic;

#nullable disable

namespace Servicio.DB
{
    public partial class Equipo
    {
        public Equipo()
        {
            Jugadors = new HashSet<Jugador>();
        }

        public int IdEquipo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Jugador> Jugadors { get; set; }
    }
}
