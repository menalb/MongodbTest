using System.Collections.Generic;
using Data.Entities;

namespace Data.Repositories
{
    public interface ILibraryRepository : IRepository<Book>
    {
        IEnumerable<Book> GetLibrary();
    }
}