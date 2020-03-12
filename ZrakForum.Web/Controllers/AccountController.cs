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
        private readonly IAuthenticationService authenticationService;
        private readonly IPasswordHasher passwordHasher;

        public AccountController(IAccountRepository accountRepository, IAuthenticationService authenticationService, IPasswordHasher passwordHasher)
        {
            this.accountRepository = accountRepository;
            this.authenticationService = authenticationService;
            this.passwordHasher = passwordHasher;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
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

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<ActionResult> Login(AccountLoginDto model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await authenticationService.AuthenticateAsync(model.Username, model.Password))
            {
                return string.IsNullOrEmpty(returnUrl) ? RedirectToAction("Index", "Home") : (ActionResult)Redirect(returnUrl);
            }

            ViewBag.LoginError = "Prijava neuspešna!";
            return View(model);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            authenticationService.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}