using System.ComponentModel.DataAnnotations;
namespace LibraryApiWebApp.Models
{
    public class Movie
    {
        public Movie()
        {
            Tickets = new List<Ticket>();
        }
        public int Id { get; set; }
        public string name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category category { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
