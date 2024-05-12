using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace LibraryApiWebApp.Models
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int CategoryId { get; set; }
    }
}
