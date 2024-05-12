using System.ComponentModel.DataAnnotations;
namespace LibraryApiWebApp.Models
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public double cost { get; set; }
        public string status { get; set; }
    }
}
