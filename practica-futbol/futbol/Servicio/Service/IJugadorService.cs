using Servicio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Service
{
    public interface IJugadorService
    {
        void Agregar(Jugador jugador);

        void Editar (Jugador jugador);

        void Eliminar(int id);
        List<Jugador> ObtenerJugadoresPorEquipo(int id);

        List<Jugador> ObtenerTodos();
    }
}
