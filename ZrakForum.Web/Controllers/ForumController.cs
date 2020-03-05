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
        private readonly IThreadRepository threadRepository;

        public ForumController(IForumRepository forumRepository, IThreadRepository threadRepository)
        {
            this.forumRepository = forumRepository;
            this.threadRepository = threadRepository;
        }

        [Authorize]
        public async Task<ActionResult> Show(string forumName, string threadName)
        {
            if (string.IsNullOrEmpty(threadName))
            {
                var threads = await threadRepository.GetForumThreadsByForumNameAsync(forumName);
                return View(threads);
            }

            var thread = await threadRepository.GetByNameAsync(Server.UrlDecode(threadName));
            return View("~/Views/Thread/Show.cshtml", thread);
        }
    }
}