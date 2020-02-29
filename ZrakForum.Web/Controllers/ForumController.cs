using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZrakForum.Web.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        public ActionResult Index(string forumName)
        {
            return View();
        }
    }
}