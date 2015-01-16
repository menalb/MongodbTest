using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using MongoDB.Driver.Linq;

namespace Data.Repositories
{
    public class LibraryRepository : Repository<Book>, ILibraryRepository
    {
        public LibraryRepository(string connectionString, string dbName) : base(connectionString, dbName)
        {
        }

        public IEnumerable<Book> GetLibrary()
        {
            return MongoConnectionHandler.MongoCollection.AsQueryable().ToList();
        }

        public override void Update(Book enity)
        {
        }
    }
}