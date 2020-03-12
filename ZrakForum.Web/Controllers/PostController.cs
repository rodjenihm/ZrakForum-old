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
    public class PostController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IThreadRepository threadRepository;
        private readonly IPostRepository postRepository;

        public PostController(IAccountRepository accountRepository, IThreadRepository threadRepository, IPostRepository postRepository)
        {
            this.accountRepository = accountRepository;
            this.threadRepository = threadRepository;
            this.postRepository = postRepository;
        }

        [HttpGet]
        public ActionResult Create(string onThread)
        {
            ViewBag.OnThread = Server.UrlDecode(onThread);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostCreateDto model, string onThread)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var thread = await threadRepository.GetByNameAsync(onThread);
            var author = await accountRepository.GetByUsernameAsync(User.Identity.Name);

            var newPost = new Post
            {
                Content = model.Content,
                AuthorId = author.Id,
                ThreadId = thread.Id
            };

            await postRepository.AddAsync(newPost);

            return RedirectToAction("Show", "Forum", new { threadName = Server.UrlDecode(onThread) });
        }
    }
}