namespace LibraryApiWebApp.Models
{
    public class Category
    {
        public Category()
        {
            Movies = new List<Movie>();
        }
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}