using System.Web.Mvc;

namespace TodMovies.Controllers
{
    public class RentalController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}