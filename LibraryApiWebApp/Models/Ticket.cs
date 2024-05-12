using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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
        public int? PaymentId { get; set; }
        public int? MovieId { get; set; }
        [JsonIgnore]
        public virtual Payment? payment { get; set; }
        [JsonIgnore]
        public virtual Movie? movie { get; set; }
    }
}

