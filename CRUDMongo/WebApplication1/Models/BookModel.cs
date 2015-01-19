using System.ComponentModel.DataAnnotations;

namespace CRUDMongoWeb.Models
{
    public class BookModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
    }
}