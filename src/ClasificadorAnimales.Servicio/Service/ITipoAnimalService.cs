using ClasificadorAnimales.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasificadorAnimales.Servicio.Service
{
    public interface ITipoAnimalService
    {
        List<TipoAnimal> ObtenerTodos();
    }
}
