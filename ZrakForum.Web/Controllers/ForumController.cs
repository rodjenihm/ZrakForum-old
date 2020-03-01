using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZrakForum.DataAccess.Repositories;

namespace ZrakForum.Web.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumRepository forumRepository;

        public ForumController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        // GET: Forum
        public async Task<ActionResult> Index(string forumName)
        {
            var forum = await forumRepository.GetByNameAsync(forumName);
            return View(forum);
        }
    }
}