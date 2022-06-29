using BD.DB;
using System.Collections.Generic;

namespace ObrasDeArte.Service
{
    public interface IObraDeArteService
    {

        List<ObraDeArte> ListarObras();

        void AgregarObra(ObraDeArte obraDeArte);

        List<ObraDeArte> ObrasDeArteSigloXIX();

        void Eliminar(int idObraDeArte);

        void Editar(ObraDeArte obra);

        ObraDeArte buscarPorId(int Id);
    }
}
