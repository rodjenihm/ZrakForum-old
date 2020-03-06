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
        private readonly IAccountRepository accountRepository;

        public ForumController(IForumRepository forumRepository, IThreadRepository threadRepository, IAccountRepository accountRepository)
        {
            this.forumRepository = forumRepository;
            this.threadRepository = threadRepository;
            this.accountRepository = accountRepository;
        }

        [Authorize]
        public async Task<ActionResult> Show(string forumName, string threadName)
        {
            if (string.IsNullOrEmpty(threadName))
            {
                var forum = await forumRepository.GetByNameAsync(forumName, true);
                return View(forum);
            }

            var thread = await threadRepository.GetByNameAsync(Server.UrlDecode(threadName));
            return View("~/Views/Thread/Show.cshtml", thread);
        }
    }
}