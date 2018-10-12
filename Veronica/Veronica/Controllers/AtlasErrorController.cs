using System;
using System.Web.Mvc;
using Veronica.DAL.Repositories;

namespace Veronica.Controllers
{
    public class AtlasErrorController : Controller
    {
        // GET: AtlasError
        public ActionResult Index()
        {
            return View("~/Views/AtlasError/ErrorDashboard.cshtml", "_SSISLayout");
        }

        [HttpGet]
        public JsonResult GetErrorList(string servername)
        {
            try
            {
                var repo = new ErrorRepositories();
                var data = repo.FetchErrorList(servername);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                //this.LogError(String.Format("{0} List controller method failed with an error of {0}:{1}", "GetKPI", e));
                //return Json(new { exception = e.Message }, JsonRequestBehavior.AllowGet);
                throw e;
            }
        }

        [HttpGet]
        public JsonResult GetAPPCount(string servername)
        {
            try
            {
                var repo = new ErrorRepositories();
                var data = repo.FetchErrorKPI(servername);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                //this.LogError(String.Format("{0} List controller method failed with an error of {0}:{1}", "GetKPI", e));
                //return Json(new { exception = e.Message }, JsonRequestBehavior.AllowGet);
                throw e;
            }
        }
    }
}