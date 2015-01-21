using System;
using System.Linq;
using MongoRepository;

namespace TestMongoRepository
{
    class Program
    {
        static MongoRepository<Customer> customerrepo = new MongoRepository<Customer>();

        static void Main(string[] args)
        {
            //Add customers
            var john = new Customer() { FirstName = "John", LastName = "Doe" };
            var jane = new Customer() { FirstName = "Jane", LastName = "Doe" };
            var jerry = new Customer() { FirstName = "Jerry", LastName = "Maguire" };
            customerrepo.Add(new[] { john, jane, jerry });

            //Show contents of DB
            DumpData();

            //Update customers
            john.FirstName = "Johnny";  //John prefers Johnny
            customerrepo.Update(john);

            jane.LastName = "Maguire";  //Jane divorces John and marries Jerry
            customerrepo.Update(jane);

            //Delete customers
            customerrepo.Delete(jerry.Id);  //Jerry passes away

            //Add some products to John and Jane
            john.Products.AddRange(new[] {
                new Product() { Name = "Fony DVD Player XY1299", Price = 35.99M },
                new Product() { Name = "Big Smile Toothpaste", Price = 1.99M }
            });
            jane.Products.Add(new Product() { Name = "Life Insurance", Price = 2500 });
            customerrepo.Update(john);
            customerrepo.Update(jane);
            //Or, alternatively: customerrepo.Update(new [] { john, jane });

            //Show contents of DB
            DumpData();

            //Finally; demonstrate GetById and First
            var mysterycustomer1 = customerrepo.GetById(john.Id);
            var mysterycustomer2 = customerrepo.First(c => c.FirstName == "Jane");

            Console.WriteLine("Mystery customer 1: {0} (having {1} products)",
                    mysterycustomer1.FirstName, mysterycustomer1.Products.Count);
            Console.WriteLine("Mystery customer 2: {0} (having {1} products)",
                    mysterycustomer2.FirstName, mysterycustomer2.Products.Count);

            //Delete all customers
            customerrepo.DeleteAll();

            //Halt for user
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static void DumpData()
        {
            //Print all data
            Console.WriteLine("Currently in our database:");
            foreach (Customer c in customerrepo)
            {
                Console.WriteLine("{0}\t{1}\t has {2} products",
                    c.FirstName, c.LastName, c.Products.Count);
                foreach (Product p in c.Products)
                    Console.WriteLine("\t{0} priced ${1:N2}", p.Name, p.Price);
                Console.WriteLine("\tTOTAL: ${0:N2}", c.Products.Sum(p => p.Price));
            }
            Console.WriteLine(new string('=', 50));
        }
    }
}
