using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using ZrakForum.DataAccess.Entities;
using ZrakForum.DataAccess.Repositories;

namespace ZrakForum.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IPasswordHasher passwordHasher;

        public AuthenticationService(IAccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            this.accountRepository = accountRepository;
            this.passwordHasher = passwordHasher;
        }

        public bool Authenticate(string username, string password)
        {
            var account = accountRepository.GetByUsername(username);

            if (account == null || !passwordHasher.VerifyHashedPassword(password, account.PasswordHash))
            {
                return false;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Username),
                new Claim(ClaimTypes.Email, account.Email),
            };

            var identity = new ClaimsIdentity(claims, "ApplicationCookie");

            var roles = accountRepository.GetRolesByUsername(username);

            if (roles.Any())
            {
                var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
                identity.AddClaims(roleClaims);
            }

            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, identity);

            return true;
        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var account = await accountRepository.GetByUsernameAsync(username);

            if (account == null || !passwordHasher.VerifyHashedPassword(password, account.PasswordHash))
            {
                return false;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Username),
                new Claim(ClaimTypes.Email, account.Email),
            };

            var identity = new ClaimsIdentity(claims, "ApplicationCookie");

            var roles = accountRepository.GetRolesByUsername(username);

            if (roles.Any())
            {
                var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
                identity.AddClaims(roleClaims);
            }

            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, identity);

            return true;
        }

        public void SignOut()
        {
            AuthenticationManager.SignOut();
        }

        public async Task SignOutAsync()
        {
            throw new NotImplementedException();
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }
    }
}