using System.ComponentModel.DataAnnotations;
namespace LibraryApiWebApp.Models
{
    public class Customer
    {
        public Customer()
        {
            Payments = new List<Payment>();
        }
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
