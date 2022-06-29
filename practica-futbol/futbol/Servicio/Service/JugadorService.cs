using Microsoft.EntityFrameworkCore;
using Servicio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Service
{
    public class JugadorService : IJugadorService
    {
        PRACTICAEQUIPOFUTBOLContext _Contexto;   
        public JugadorService(PRACTICAEQUIPOFUTBOLContext context)
        {
            this._Contexto = context;
        }
        public void Agregar(Jugador jugador)
        {
            _Contexto.Jugadors.Add(jugador);
            _Contexto.SaveChanges();
        }

        public void Editar(Jugador jugador)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int IdJugador)
        {
            Jugador jugador = _Contexto.Jugadors.Where(j => j.IdJugador == IdJugador).First();
            _Contexto.Jugadors.Remove(jugador);
            _Contexto.SaveChanges();
        }

        public List<Jugador> ObtenerJugadoresPorEquipo(int id)
        {
            return _Contexto.Jugadors.Include(e => e.IdEquipoNavigation).Where(e => e.IdEquipo == id).ToList();
        }

        public List<Jugador> ObtenerTodos()
        {
            return _Contexto.Jugadors.Include(e => e.IdEquipoNavigation).ToList();
        }
    }
}
