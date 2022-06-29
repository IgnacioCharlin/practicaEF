using BD.DB;
using System.Collections.Generic;
using System.Linq;

namespace ObrasDeArte.Service
{
    public class ObraDeArteService : IObraDeArteService
    {
        ObraDeArteContext _Contexto;
        public ObraDeArteService()
        {
            _Contexto = new ObraDeArteContext();
        }

        public void AgregarObra(ObraDeArte obraDeArte)
        {
            _Contexto.ObraDeArtes.Add(obraDeArte);
            _Contexto.SaveChanges();
        }

        public ObraDeArte buscarPorId(int Id)
        {
           return _Contexto.ObraDeArtes.Where(o => o.Id == Id).First();
        }

        public void Editar(ObraDeArte obra)
        {
            ObraDeArte obraEnBase = buscarPorId(obra.Id);
            obraEnBase.Nombre = obra.Nombre;
            obraEnBase.AnioCreacion = obra.AnioCreacion;
            _Contexto.SaveChanges();
        }

        public void Eliminar(int idObraDeArte)
        {
            ObraDeArte obraAEliminar = buscarPorId(idObraDeArte);
            _Contexto.ObraDeArtes.Remove(obraAEliminar);
            _Contexto.SaveChanges();
        }

        public List<ObraDeArte> ListarObras()
        {
            return _Contexto.ObraDeArtes.ToList();
        }

        public List<ObraDeArte> ObrasDeArteSigloXIX()
        {
            return _Contexto.ObraDeArtes.Where(o => o.AnioCreacion >= 1800 && o.AnioCreacion <= 1899).OrderByDescending(o=> o.AnioCreacion).ToList();
        }
    }
}
