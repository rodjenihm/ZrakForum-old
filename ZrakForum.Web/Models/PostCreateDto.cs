using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZrakForum.Web.Models
{
    public class PostCreateDto
    {
        [Required(ErrorMessage = "Komentar ne može biti prazan")]
        [Display(Name = "Komentar")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}