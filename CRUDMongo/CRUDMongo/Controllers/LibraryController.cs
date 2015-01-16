using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using CRUDMongo.Models;
using Data.Entities;
using Data.Repositories;

namespace CRUDMongo.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryRepository _repository;

        public LibraryController()
        {
            _repository = new LibraryRepository(
                ConfigurationManager.ConnectionStrings["MongoServer"].ConnectionString,
                ConfigurationManager.AppSettings["libraryDbName"]);
        }

        public ActionResult Index()
        {
            var l = _repository.GetLibrary().Select(x=>new BookModel
                {
                    Title = x.Title,
                    Author = x.Author
                });
            return View(l);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public void Insert(BookModel book)
        {
            _repository.Create(new Book
                {
                    Title = book.Title,
                    Author = book.Author
                });

            RedirectToAction("Index");
        }
    }
}