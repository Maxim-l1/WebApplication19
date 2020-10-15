using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication19.Models.Interface;

namespace WebApplication19.Models
{
    public class EFAnimalRepository : IAnimalDb
    {
        private readonly AnimalContext context;
        public EFAnimalRepository(AnimalContext animalContext)
        {
            context = animalContext;
        }

        public IQueryable<Animal> GetAnimals()
        {
            return context.Animals;
        }

        public Animal GetAnimalById(int id)
        {
            return context.Animals.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteAnimal(int id)
        {
            context.Animals.Remove(new Animal() { Id = id });
            context.SaveChanges();
        }

        public void SaveAnimal(Animal entity)
        {
            context.Entry(entity).State = EntityState.Added;// объект будет добавлен как новый
            context.SaveChanges();
        }

        public void UpdateAnimal(Animal entity)
        {
            context.SaveChanges();
        }
    }
}
