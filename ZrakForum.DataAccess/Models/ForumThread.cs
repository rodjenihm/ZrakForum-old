using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZrakForum.DataAccess.Models
{
    public class ForumThread
    {
        public DateTime StartedAt { get; set; }

        [Display(Name = "Tema")]
        public string ThreadName { get; set; }

        [Display(Name = "Temu pokrenuo")]
        public string StartedBy { get; set; }
    }
}
