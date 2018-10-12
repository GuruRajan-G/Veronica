using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Veronica.DAL.Repositories;

namespace Veronica.Controllers
{
    public class DollarController : Controller
    {
        // GET: Dollar
        public ActionResult Index()
        {
            return View("~/Views/Dollar/DollarActiveJob.cshtml", "_SSISLayout");
        }

        [HttpGet]
        public JsonResult GetActiveJob()
        {
            try
            {
                var repo = new DollarRepository();
                var data = repo.FetchActiveJob();
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