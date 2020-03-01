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

        // GET: Forum
        public async Task<ActionResult> Index(string forumName)
        {
            var threads = await threadRepository.GetByForumNameAsync(forumName);
            return View(threads);
        }
    }
}