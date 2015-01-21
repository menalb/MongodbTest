using System.Collections.Generic;
using MongoRepository;

namespace TestMongoRepository
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Product> Products { get; set; }

        public Customer()
        {
            this.Products= new List<Product>();
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}