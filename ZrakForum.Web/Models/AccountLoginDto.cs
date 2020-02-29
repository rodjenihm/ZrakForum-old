using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZrakForum.Web.Models
{
    public class AccountLoginDto
    {
        [Required(ErrorMessage = "Korisničko ime je obavezno")]
        [Display(Name = "Korisničko ime")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Šifra je obavezna")]
        [DataType(DataType.Password)]
        [Display(Name = "Šifra")]
        public string Password { get; set; }
    }
}