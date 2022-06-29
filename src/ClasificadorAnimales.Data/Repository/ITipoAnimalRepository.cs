using ClasificadorAnimales.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasificadorAnimales.Data.Repository
{
    public interface ITipoAnimalRepository
    {
        List<TipoAnimal> obtenerTodos();
    }
}
