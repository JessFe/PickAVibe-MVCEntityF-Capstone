using System.Web.Mvc;

namespace PickAVibe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/About
        public ActionResult About()
        {

            return View();
        }

    }
}