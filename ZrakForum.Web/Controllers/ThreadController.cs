using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZrakForum.Web.Controllers
{
    public class ThreadController : Controller
    {
        // GET: Thread
        public ActionResult Show(string threadName)
        {
            return View();
        }
    }
}