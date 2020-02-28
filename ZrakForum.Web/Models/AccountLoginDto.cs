using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZrakForum.Web.Models
{
    public class AccountLoginDto
    {
        [Required(ErrorMessage = "Email adresa je obavezna")]
        [EmailAddress(ErrorMessage = "Email adresa nije validna")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Šifra je obavezna")]
        [DataType(DataType.Password)]
        [Display(Name = "Šifra")]
        public string Password { get; set; }
    }
}