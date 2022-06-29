using ClasificadorAnimales.Data.EF;
using ClasificadorAnimales.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasificadorAnimales.Servicio.Service
{
    public class AnimalServices : IAnimalServices
    {
        IAnimalRepository _animalRepository;

        public AnimalServices(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public Animal AnimalPorId(int idAnimal)
        {
            return _animalRepository.AnimalPorId(idAnimal);
        }

        public void Eliminar(int idAnimal)
        {
            _animalRepository.eliminar(idAnimal);
        }

        public void Insertar(Animal animal)
        {
            _animalRepository.Insertar(animal);
        }

        public Animal ModificarAnimal(Animal animal)
        {
            return _animalRepository.Modificar(animal);
        }

        public List<Animal> ObtenerPorTipo(int tipoAnimal)
        {
            return _animalRepository.obtenerPorTipo(tipoAnimal);
        }

        public List<Animal> ObtenerTodos()
        {
            return _animalRepository.obtenerTodos();
        }
    }
}
