using ClasificadorAnimales.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasificadorAnimales.Data.Repository
{
    public class AnimalRepository : BaseRepository, IAnimalRepository
    {
        public AnimalRepository(_20221CPracticaEFContext contexto) : base(contexto)
        {
        }

        public Animal AnimalPorId(int idAnimal)
        {
            return _Contexto.Animals.Include(o => o.IdTipoAnimalNavigation).Where(o => o.IdAnimal == idAnimal).FirstOrDefault();
        }

        public void eliminar(int idAnimal)
        {
            Animal animales = _Contexto.Animals.Include(o => o.IdTipoAnimalNavigation).Where(o => o.IdAnimal == idAnimal).FirstOrDefault();
            _Contexto.Animals.Remove(animales);
            _Contexto.SaveChanges();
        }

        public void Insertar(Animal animal)
        {
            _Contexto.Animals.Add(animal);
            _Contexto.SaveChanges();
        }

        public Animal Modificar(Animal animalModificado)
        {
            Animal animal = _Contexto.Animals.Include(o => o.IdTipoAnimalNavigation).Where(o => o.IdAnimal == animalModificado.IdAnimal).FirstOrDefault();
            if(animal == null)
            {
                return null;
            }
            animal.NombreEspecie = animalModificado.NombreEspecie;
            animal.IdTipoAnimal = animalModificado.IdAnimal;
            animal.EdadPromedio = animalModificado.EdadPromedio;
            animal.PesoPromedio = animalModificado.PesoPromedio;
            _Contexto.SaveChanges();
            return animalModificado;

        }

        public List<Animal> obtenerPorTipo(int idTipoAnimal)
        {
            return _Contexto.Animals.Include(o => o.IdTipoAnimalNavigation)
                .Where(o=> o.IdTipoAnimal == idTipoAnimal).ToList();
        }

        public List<Animal> obtenerTodos()
        {
            return _Contexto.Animals.Include(o=>o.IdTipoAnimalNavigation).ToList();
        }
    }
}
