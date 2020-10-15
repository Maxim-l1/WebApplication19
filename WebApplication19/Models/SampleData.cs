using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    //класс инициализатор базы данных
    public static class SampleData
    {
        public static void Initialize(AnimalContext context)
        {
            //если данные в таблице Phones в бд отсутствуют
            if (!context.Animals.Any())
            {
                context.Animals.AddRange(
                    new Animal
                    {
                        Kind = "Кот",
                        Date = new DateTime(2018, 2, 16),
                        Age = 2,
                        Sex = "M",
                        PathImage = "/img/image1.jpg"
                    },
                    new Animal
                    {
                        Kind = "Собака",
                        Date = new DateTime(2018, 10, 8),
                        Age = 2.2,
                        Sex = "Ж",
                        PathImage = "/img/image2.jpg"
                    },
                    new Animal
                    {
                        Kind = "Морская свинка",
                        Date = new DateTime(2017, 9, 27),
                        Age = 3.4,
                        Sex = "М",
                        PathImage = "/img/image3.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
