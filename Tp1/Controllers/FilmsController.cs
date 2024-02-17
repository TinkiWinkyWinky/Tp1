using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tp1.Models;
using Tp1.ViewModels;
using System.Linq;

namespace Tp1.Controllers
{
    public class FilmsController : Controller
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
        public IActionResult Index()
        {
            var filmIndexVM = new FilmIndexVM
            {
                Films = films
            };

            return View(filmIndexVM);
        }

        [Route("/Films/Index/{annee}")]
        public IActionResult Index(int annee)
        {
            var filmIndexVM = new FilmIndexVM
            {
                Films = films.Where(e => e.DateSortie.Year == annee).ToList()
            };

            return View(filmIndexVM);
        }

        [Route("/Films/Details/{id}")]
        public IActionResult Details(int id)
        {
            FilmModel film = films.FirstOrDefault(e => e.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        [HttpPost]
        [Route("/Films/Details")]
        public IActionResult DetailsPost(int id)
        {
            return RedirectToAction("Details", new { id = id });
        }
    }
}