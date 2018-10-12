using System;
using System.Collections.Generic;
using Veronica.DAL.Repositories;
using Veronica.Models;
using System.Web.Mvc;

namespace Veronica.Controllers
{
    public class SSISController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/SSISDashboard/Index.cshtml", "_SSISLayout");
            //return Viw();
        }


        [HttpGet]
        public JsonResult GetKPI(string servername)
        {
            try
            {
                var repo = new KpiRepository();
                var data = repo.Fetch(servername);
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
        public JsonResult GetExecutions(string servername)
        {
            try
            {
                var repo = new ExecutionRepository();
                var data = repo.Fetch(servername);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                //this.LogError(String.Format("{0} List controller method failed with an error of {0}:{1}", "GetExecutions", e));
                //return Json(new { exception = e.Message }, JsonRequestBehavior.AllowGet);
                throw e;

            }
        }

        [HttpGet]
        public JsonResult GetExecutables(int executionId, string servername)
        {
            try
            {
                var repo = new ExecutableRepository();
                var data = repo.Fetch(executionId, servername);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                //this.LogError(String.Format("{0} List controller method failed with an error of {0}:{1}", "GetExecutables", e));
                //return Json(new { exception = e.Message }, JsonRequestBehavior.AllowGet);
                throw e;
            }
        }

        [HttpGet]
        public JsonResult GetMessages(int executionId, string type, string servername)
        {
            MessageType messageType = MessageType.Unknown;
            switch (type)
            {
                case "error":
                    messageType = MessageType.Error;
                    break;
                case "warning":
                    messageType = MessageType.Warning;
                    break;
            }

            try
            {
                if (messageType == MessageType.Unknown)
                {
                    throw new ArgumentException(String.Format("Unknown messagae type of:'{0}'.", type));
                }
                var data = new MessageRepository().Fetch(executionId, messageType, servername);
                return Json(data, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                //this.LogError(String.Format("{0} List controller method failed with an error of {0}:{1}", "GetMessges", e));
                //return Json(new { exception = e.Message }, JsonRequestBehavior.AllowGet);
                throw e;
            }
        }

        private List<Message> GetMessages(int executionId, MessageType messageType, string servername)
        {
            return new MessageRepository().Fetch(executionId, messageType, servername);

        }
    }
}
