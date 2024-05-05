using System.ComponentModel.DataAnnotations;
namespace LibraryApiWebApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int row { get; set; }
        public int seat { get; set; }
        public string status { get; set; }
        public double price { get; set; }
        public DateTime datetime { get; set; }
        public virtual Payment payment { get; set; }
        public virtual Movie movie { get; set; }
    }
}

