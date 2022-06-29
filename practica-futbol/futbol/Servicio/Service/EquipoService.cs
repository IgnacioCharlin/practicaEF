using Servicio.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Service
{
    public class EquipoService : IEquipoService
    {
        PRACTICAEQUIPOFUTBOLContext _Contexto;
        public EquipoService(PRACTICAEQUIPOFUTBOLContext contexto)
        {
            this._Contexto = contexto;
        }
        public List<Equipo> listarEquipos()
        {
            return _Contexto.Equipos.ToList();
        }
    }
}
