using Microsoft.EntityFrameworkCore;
namespace LibraryApiWebApp.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class Customer
    {
        public Customer()
        {
            Payments = new List<Payment>();
        }
        public int Id { get; set; }
        
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
