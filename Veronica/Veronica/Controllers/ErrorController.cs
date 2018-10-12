using System.Web.Mvc;

namespace Veronica.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
