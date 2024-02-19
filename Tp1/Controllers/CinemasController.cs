using Microsoft.AspNetCore.Mvc;
using TP1.Models;
using TP1.ViewModels;

namespace TP1.Controllers
{
    public class CinemasController : Controller
    {
        private List<Cinema> cinemas = new()
        {
            new()
            {
                Id = 1, Nom = "Cinéma Granby 1", DateCreation = new DateTime(2000, 01, 01), NombreSalles = 10,
                Courriel = "cg1@cinemas.com", Telephone = "450-001-0001", Ville = "Granby"
            },
            new()
            {
                Id = 2, Nom = "Cinéma Granby 2", DateCreation = new DateTime(2000, 01, 01), NombreSalles = 6,
                Courriel = "cg2@cinemas.com", Telephone = "450-001-0002", Ville = "Granby"
            },
            new()
            {
                Id = 3, Nom = "Cinéma Sherbrooke 1", DateCreation = new DateTime(2000, 01, 01), NombreSalles = 7,
                Courriel = "cs1@cinemas.com", Telephone = "450-002-0001", Ville = "Sherbrooke"
            },
            new()
            {
                Id = 4, Nom = "Cinéma Sherbrooke 2", DateCreation = new DateTime(2000, 01, 01), NombreSalles = 8,
                Courriel = "cs2@cinemas.com", Telephone = "450-002-0002", Ville = "Sherbrooke"
            },
            new()
            {
                Id = 5, Nom = "Cinéma Sherbrooke 3", DateCreation = new DateTime(2000, 01, 01), NombreSalles = 14,
                Courriel = "cs3@cinemas.com", Telephone = "450-002-0003", Ville = "Sherbrooke"
            },
            new()
            {
                Id = 6, Nom = "Cinéma Montréal 1", DateCreation = new DateTime(2000, 01, 01), NombreSalles = 5,
                Courriel = "cm1@cinemas.com", Telephone = "450-003-0001", Ville = "Montréal"
            },
            new()
            {
                Id = 7, Nom = "Cinéma Montréal 2", DateCreation = new DateTime(2000, 01, 01), NombreSalles = 6,
                Courriel = "cm2@cinemas.com", Telephone = "450-003-0002", Ville = "Montréal"
            },
            new()
            {
                Id = 8, Nom = "Cinéma Montréal 3", DateCreation = new DateTime(2000, 01, 01), NombreSalles = 9,
                Courriel = "cm3@cinemas.com", Telephone = "450-003-0003", Ville = "Montréal"
            },
            new()
            {
                Id = 9, Nom = "Cinéma Montréal 4", DateCreation = new DateTime(2000, 01, 01), NombreSalles = 15,
                Courriel = "cm4@cinemas.com", Telephone = "450-003-0004", Ville = "Montréal"
            },
            new()
            {
                Id = 10, Nom = "Cinéma Montréal 5", DateCreation = new DateTime(2000, 01, 01), NombreSalles = 25,
                Courriel = "cm5@cinemas.com", Telephone = "450-003-0005", Ville = "Montréal"
            },
        };

        [Route("{controller}")]
        [Route("{controller}/{action}")]
        public IActionResult Index([FromQuery] string? ville)
        {
            
            IEnumerable<CinemaVM> cinemaVms = cinemas.Select(x => new CinemaVM()
                {
                    Id = x.Id,
                    Nom = x.Nom,
                    NombreSalles = x.NombreSalles,
                    Ville = x.Ville
                }
            );
            if (ville != null)
            {
                cinemaVms = cinemaVms.Where(c => c.Ville.Equals(ville)).ToList();
            }

            return View(cinemaVms.ToList());
        }

        [Route("{controller}/{action}/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {

            IEnumerable<CinemaVM> cinemaVms = cinemas.Select(x => new CinemaVM()
                {
                    Id = x.Id,
                    Nom = x.Nom,
                    NombreSalles = x.NombreSalles,
                    Ville = x.Ville
                }
            );
            var cinema = cinemaVms.FirstOrDefault(c => c.Id == id);

            if (cinema != null)
            {
                return View(cinema);
            }

            return NotFound();

        }

    }
}
