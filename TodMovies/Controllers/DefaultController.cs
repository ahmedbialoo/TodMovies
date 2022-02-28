using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Home()
        {
            return File("~/Pages/Home.html", "text/html");
        }
    }
}