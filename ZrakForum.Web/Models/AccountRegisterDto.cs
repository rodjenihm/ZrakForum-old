using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZrakForum.Web.Models
{
    public class AccountRegisterDto
    {
        [Required(ErrorMessage = "Email adresa je obavezna")]
        [EmailAddress(ErrorMessage = "Email adresa nije validna")]
        [Display(Name = "Email adresa")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Korisničko ime je obavezno")]
        [StringLength(30, ErrorMessage = "Korisničko ime mora imati najmanje {2} a najviše {1} karaktera", MinimumLength = 4)]
        [Display(Name = "Korisničko ime")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Šifra je obavezna")]
        [StringLength(30, ErrorMessage = "Šifra mora imati najmanje {2} a najviše {1} karaktera", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Šifra")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdite šifru")]
        [Compare("Password", ErrorMessage = "Šifre se ne podudaraju")]
        public string ConfirmPassword { get; set; }
    }
}