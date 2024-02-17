using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tp1.Models;
using Tp1.ViewModels;

namespace Tp1.Controllers
{
    public class HomeController : Controller
    {
        static readonly List<FilmModel> films = new()
        {
            new FilmModel() { Id = 0, Titre = "TitreA", DateSortie = new DateTime(2008, 8, 23), Categorie = "CategorieA", CheminImage = "/images/test1.jpg", BudgetRealisation = 0.00},
            new FilmModel() { Id = 1, Titre = "TitreB", DateSortie = new DateTime(2009, 8, 23), Categorie = "CategorieB", CheminImage = "/images/test2.jpg", BudgetRealisation = 0.00},
            new FilmModel() { Id = 2, Titre = "TitreC", DateSortie = new DateTime(2010, 8, 23), Categorie = "CategorieC", CheminImage = "/images/test3.jpg", BudgetRealisation = 0.00},
            new FilmModel() { Id = 3, Titre = "TitreD", DateSortie = new DateTime(2011, 8, 23), Categorie = "CategorieD", CheminImage = "/images/test4.jpg", BudgetRealisation = 0.00},
            new FilmModel() { Id = 4, Titre = "TitreE", DateSortie = new DateTime(2012, 8, 23), Categorie = "CategorieE", CheminImage = "/images/test5.jpg", BudgetRealisation = 0.00},
            new FilmModel() { Id = 5, Titre = "TitreF", DateSortie = new DateTime(2013, 8, 23), Categorie = "CategorieF", CheminImage = "/images/test6.jpg", BudgetRealisation = 0.00},
            new FilmModel() { Id = 6, Titre = "TitreG", DateSortie = new DateTime(2014, 8, 23), Categorie = "CategorieG", CheminImage = "/images/test7.jpg", BudgetRealisation = 0.00},
            new FilmModel() { Id = 7, Titre = "TitreH", DateSortie = new DateTime(2015, 8, 23), Categorie = "CategorieH", CheminImage = "/images/test8.jpg", BudgetRealisation = 0.00},
            new FilmModel() { Id = 8, Titre = "TitreI", DateSortie = new DateTime(2016, 8, 23), Categorie = "CategorieI", CheminImage = "/images/test9.jpg", BudgetRealisation = 0.00},
            new FilmModel() { Id = 9, Titre = "TitreJ", DateSortie = new DateTime(2017, 8, 23), Categorie = "CategorieJ", CheminImage = "/images/test10.jpg", BudgetRealisation = 0.00}
        };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var filmIndexVM = new FilmIndexVM
            {
                Films = films.OrderByDescending(e => e.DateSortie).Take(3).ToList()
            };

            return View(filmIndexVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
