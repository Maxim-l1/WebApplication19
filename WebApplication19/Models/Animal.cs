using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication19.Models.Interface;

namespace WebApplication19.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Display(Name = "Вид животного")]
        public string Kind { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime Date { get; set; }
        public double Age { get; set; }

        [Display(Name = "Пол")]
        public string Sex { get; set; }

        [Display(Name = "Картинка")]
        public string PathImage { get; set; }
    }
}
