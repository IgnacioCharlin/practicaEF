using ClasificadorAnimales.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasificadorAnimales.Data.Repository
{
    public class TipoAnimalRepository : BaseRepository, ITipoAnimalRepository
    {
        
        public TipoAnimalRepository(_20221CPracticaEFContext contexto) : base(contexto)
        {
        }

        public List<TipoAnimal> obtenerTodos()
        {
            return _Contexto.TipoAnimals.ToList();
        }
    }
}
