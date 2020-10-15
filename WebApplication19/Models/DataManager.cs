using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication19.Models.Interface;

namespace WebApplication19.Models
{
    public class DataManager
    {
        public IAnimalDb Animals { get; set; }

        public DataManager(IAnimalDb animals)
        {
            Animals = animals;
        }
    }
}
