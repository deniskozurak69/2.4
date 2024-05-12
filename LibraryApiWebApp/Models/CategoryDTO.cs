using System.ComponentModel.DataAnnotations;
namespace LibraryApiWebApp.Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}