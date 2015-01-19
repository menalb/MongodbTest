using System.ComponentModel.DataAnnotations;

namespace CRUDMongoWeb.Models
{
    public class BookModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public AuthorModel Author { get; set; }
    }

    public class AuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}