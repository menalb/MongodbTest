using System.Linq;
using System.Web.Mvc;
using CRUDMongoWeb.Models;
using Data.Entities;
using Data.Repositories;

namespace CRUDMongoWeb.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryRepository _repository;

        public LibraryController(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var l = _repository.GetLibrary().Select(x => new BookModel
                {
                    Title = x.Title,
                    Author = new AuthorModel
                        {
                            Name = x.Author.Name,
                            Surname = x.Author.Surname
                        }
                });
            return View(l);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(BookModel book)
        {
            _repository.Create(new Book
                {
                    Title = book.Title,
                    Author = new Author
                        {
                            Name = book.Author.Name,
                            Surname = book.Author.Surname
                        }
                });

            return RedirectToAction("Index", "Library");
        }
    }
}