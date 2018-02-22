using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Toeb.Controllers.MVC
{
    public class AgentController : Controller
    {
        // GET: Agent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ServiceCharges()
        {
            return View();
        }
    }
}