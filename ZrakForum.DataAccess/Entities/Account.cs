﻿namespace ZrakForum.DataAccess.Entities
{
    public class Account : BaseEntity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}