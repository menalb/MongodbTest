using System.Web.Mvc;

namespace CRUDMongoWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Library");
        }
	}
}