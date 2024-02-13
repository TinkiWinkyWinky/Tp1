namespace Tp1.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime DateSortie { get; set; }
        public string Categorie { get; set; }
        public string CheminImage { get; set; }
        public double BudgetRealisation { get; set; }
    }
}
