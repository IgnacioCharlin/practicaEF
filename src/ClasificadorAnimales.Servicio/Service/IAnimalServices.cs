using ClasificadorAnimales.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasificadorAnimales.Servicio.Service
{
    public interface IAnimalServices
    {
        List<Animal> ObtenerTodos();

        void Insertar(Animal animal);

        List<Animal> ObtenerPorTipo(int tipoAnimal);

        void Eliminar(int idAnimal);

        Animal ModificarAnimal(Animal animal);

        Animal AnimalPorId(int idAnimal);
    }
}
