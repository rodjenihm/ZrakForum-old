using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZrakForum.DataAccess.Repositories;

namespace ZrakForum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IForumRepository forumRepository;

        public HomeController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        // GET: Home
        public async Task<ActionResult> Index()
        {
            var model = await forumRepository.GetAllAsync();
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}