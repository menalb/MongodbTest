using System.ComponentModel.DataAnnotations;

namespace CRUDMongo.Models
{
    public class BookModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
    }
}