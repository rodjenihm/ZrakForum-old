using System;
using System.Collections.Generic;
using System.Linq;
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

            return true;
        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }

    public interface IAuthenticationService
    {
        bool Authenticate(string username, string password);
        Task<bool> AuthenticateAsync(string username, string password);
    }
}