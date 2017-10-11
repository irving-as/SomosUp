using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcopioUP.Controllers
{
    public class VictimsController : Controller
    {
        // GET: Victims
        public ActionResult Index()
        {
            //return View("ReadOnlyList");
            return View("List");
        }
    }
}