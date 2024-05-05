using System.ComponentModel.DataAnnotations;
namespace LibraryApiWebApp.Models
{
    public class Payment
    {
        public Payment()
        {
            Tickets = new List<Ticket>();
        }
        public int Id { get; set; }
        public double cost { get; set; }
        public string status { get; set; }
        public virtual Customer customer { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
