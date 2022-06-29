using ClasificadorAnimales.Data.EF;
using ClasificadorAnimales.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasificadorAnimales.Servicio.Service
{
    public class TipoAnimalService : ITipoAnimalService
    {
        ITipoAnimalRepository _tipoAnimalRepository;
        public TipoAnimalService(ITipoAnimalRepository tipoAnimalRepository)
        {
            _tipoAnimalRepository = tipoAnimalRepository;
        }
        public List<TipoAnimal> ObtenerTodos()
        {
            return _tipoAnimalRepository.obtenerTodos();
        }
    }
}
