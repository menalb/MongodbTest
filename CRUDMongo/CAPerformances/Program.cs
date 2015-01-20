using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace CAPerformances
{
    class Program
    {
        public static MongoCollection<Entity> collection;

        public static void Main(string[] args)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);

            var server = client.GetServer();
            var db = server.GetDatabase(("MVCTestDB"));

            collection = db.GetCollection<Entity>("entities");


            Console.WriteLine("INSERT");
            var dt = DateTime.Now;
            TestInsert();
            Console.WriteLine("Insert total time: {0}", DateTime.Now.Subtract(dt));

            Console.WriteLine("SEARCH");
            dt = DateTime.Now;
            TestSearch();
            Console.WriteLine("search total time: {0}", DateTime.Now.Subtract(dt));

            Console.WriteLine("SEARCH ALL");
            dt = DateTime.Now;
            var s = TestSearchAll();
            Console.WriteLine("search all total time: {0}", DateTime.Now.Subtract(dt));
            //Console.WriteLine(s);

            Console.WriteLine("DELETE");
            dt = DateTime.Now;
            TestDelete();
            Console.WriteLine("Delete total time: {0}", DateTime.Now.Subtract(dt));

            Console.ReadKey();
        }

        public static void TestInsert()
        {
            for (var i = 0; i < 1000000; i++)
            {
                var e = new Entity
                {
                    Name = "Name_" + i,
                    Child = new EntityChild
                        {
                            Surname = "Surname_" + i,
                            Name = "Name_" + i,
                            Phone = "Phone_" + i,
                            Address = "Address_" + i
                        }
                };
                collection.Insert(e);
            }
        }

        public static void TestSearch()
        {
            var query = Query<Entity>.EQ(e => e.Name, "Name_578999");
            var entity = collection.FindOne(query);
            Console.WriteLine("Id: {0} Name: {1}", entity.Id, entity.Name);
        }

        public static string TestSearchAll()
        {
            var entities = collection.FindAll();
            var sb = new System.Text.StringBuilder();
            foreach (var entity in entities)
            {
                sb.AppendFormat("Id: {0} Name: {1}", entity.Id, entity.Name);
            }
            return sb.ToString();
        }

        public static void TestDelete()
        {
            collection.RemoveAll();
        }
    }

    public class Entity
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public EntityChild Child { get; set; }
    }

    public class EntityChild
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}