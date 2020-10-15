using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models.Interface
{
    public interface IAnimalDb
    {
        IQueryable<Animal> GetAnimals();
        Animal GetAnimalById(int id);
        void SaveAnimal(Animal entity);
        void DeleteAnimal(int id);
        void UpdateAnimal(Animal entity);
    }
}
