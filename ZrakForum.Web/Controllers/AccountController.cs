using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZrakForum.DataAccess.Entities;
using ZrakForum.DataAccess.Repositories;
using ZrakForum.Web.Models;
using ZrakForum.Web.Services;

namespace ZrakForum.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IPasswordHasher passwordHasher;

        public AccountController(IAccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            this.accountRepository = accountRepository;
            this.passwordHasher = passwordHasher;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(AccountRegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await accountRepository.GetByUsernameAsync(model.Username) != null)
            {
                ModelState.AddModelError(nameof(model.Username), $"Korisničko ime '{model.Username}' je zauzeto");
                return View(model);
            }

            if (await accountRepository.GetByEmailAsync(model.Email) != null)
            {
                ModelState.AddModelError(nameof(model.Email), $"Email adresa '{model.Email}' je zauzeta");
                return View(model);
            }

            var newAccount = new Account
            {
                Email = model.Email,
                Username = model.Username,
                PasswordHash = passwordHasher.HashPassword(model.Password)
            };

            await accountRepository.AddAsync(newAccount);

            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountLoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View();
        }
    }
}