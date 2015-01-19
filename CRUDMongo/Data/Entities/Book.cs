namespace Data.Entities
{
    public class Book: Entity
    {
        public string Title { get; set; }
        public Author Author { get; set; }
    }
}