using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZrakForum.DataAccess.Entities;
using ZrakForum.DataAccess.Repositories;
using ZrakForum.Web.Models;

namespace ZrakForum.Web.Controllers
{
    [Authorize]
    public class ThreadController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IForumRepository forumRepository;
        private readonly IThreadRepository threadRepository;
        private readonly IPostRepository postRepository;

        public ThreadController(IAccountRepository accountRepository,
            IForumRepository forumRepository,
            IThreadRepository threadRepository,
            IPostRepository postRepository)
        {
            this.accountRepository = accountRepository;
            this.forumRepository = forumRepository;
            this.threadRepository = threadRepository;
            this.postRepository = postRepository;
        }

        [HttpGet]
        public ActionResult Create(string onForum)
        {
            ViewBag.OnForum = Server.UrlDecode(onForum);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ThreadCreateDto model, string onForum)
        {
            // This code is a big mess
            // Now I understand why is generating your own primary key with GUID better than letting database autogenerate it.

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var forum = await forumRepository.GetByNameAsync(onForum);
            var author = await accountRepository.GetByUsernameAsync(User.Identity.Name);

            var newThread = new Thread
            {
                Name = model.Name,
                AuthorId = author.Id,
                ForumId = forum.Id
            };

            await threadRepository.AddAsync(newThread);

            newThread = await threadRepository.GetByNameAsync(model.Name);

            var newPost = new Post
            {
                Content = model.Post.Content,
                AuthorId = author.Id,
                ThreadId = newThread.Id
            };

            await postRepository.AddAsync(newPost);

            return RedirectToAction(onForum, "Forum", new { threadName = Server.UrlEncode(model.Name) });
        }
    }
}