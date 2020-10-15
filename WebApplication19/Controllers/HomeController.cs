using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class HomeController : Controller
    {
        AnimalContext db;
        DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment; //для сохранения картинок

        public HomeController(AnimalContext context, IWebHostEnvironment hostingEnvironment, DataManager data)
        {
            db = context;
            this.hostingEnvironment = hostingEnvironment;
            dataManager = data;
        }

        public IActionResult Index()
        {
            return View(db.Animals.ToList());
        }
        public IActionResult Order()
        {
            return View(db.Orders.ToList());
        }

        #region BuyController
        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            ViewBag.AnimalId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            order.Animal = db.Animals.ToList().FirstOrDefault(e => e.Id == order.AnimalId);
            db.Orders.Add(order);
            db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }
        #endregion

        #region AddController
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Animal animal, IFormFile pathImage)
        {
            if (pathImage != null)
            {
                animal.PathImage = pathImage.FileName;
                using var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "img/", pathImage.FileName), FileMode.Create);
                pathImage.CopyTo(stream);
                animal.PathImage = "/img/" + pathImage.FileName;
            }
            animal.Age = DateTime.Today.Subtract(animal.Date).Days;
            dataManager.Animals.SaveAnimal(animal);
            return RedirectToAction(nameof(HomeController.Index));
        }
        #endregion

        #region DeleteController
        [HttpGet]
        public IActionResult Delete(int id)
        {
            dataManager.Animals.DeleteAnimal(id);
            return RedirectToAction(nameof(HomeController.Index));
        }
        #endregion

        #region EditController
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Animal animal = dataManager.Animals.GetAnimalById(id);
            return View(animal);
        }

        [HttpPost]
        public IActionResult Edit(Animal animal, IFormFile pathImage)
        {
            if (pathImage != null)
            {
                animal.PathImage = pathImage.FileName;
                using var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "img/", pathImage.FileName), FileMode.Create);
                pathImage.CopyTo(stream);
                animal.PathImage = "/img/" + pathImage.FileName;
            }
            animal.Age = DateTime.Today.Subtract(animal.Date).Days;
            dataManager.Animals.UpdateAnimal(animal);
            return RedirectToAction(nameof(HomeController.Index));
        }
        #endregion
    }
}
