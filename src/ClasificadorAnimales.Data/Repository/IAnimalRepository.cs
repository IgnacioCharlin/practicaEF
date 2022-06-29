using ClasificadorAnimales.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasificadorAnimales.Data.Repository
{
    public interface IAnimalRepository
    {
        void Insertar(Animal animal);

        List<Animal> obtenerTodos();

        List<Animal> obtenerPorTipo(int idTipoAnimal);

        void eliminar (int idAnimal);

        Animal Modificar(Animal animal);

        Animal AnimalPorId(int idAnimal);

    }
}
