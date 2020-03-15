using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZrakForum.DataAccess.Repositories;
using ZrakForum.Web.Models;

namespace ZrakForum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IForumRepository forumRepository;
        private readonly IThreadRepository threadRepository;
        private readonly IPostRepository postRepository;

        public HomeController(IForumRepository forumRepository,
            IThreadRepository threadRepository,
            IPostRepository postRepository)
        {
            this.forumRepository = forumRepository;
            this.threadRepository = threadRepository;
            this.postRepository = postRepository;
        }

        // GET: Home
        public async Task<ActionResult> Index()
        {
            var model = (await forumRepository.GetAllAsync()).Select(f => new ForumInfo
            {
                Name = f.Name,
                Description = f.Description,
                ThreadCount = threadRepository.CountByForum(f.Name),
                PostCount = postRepository.CountByForum(f.Name)
            });
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}