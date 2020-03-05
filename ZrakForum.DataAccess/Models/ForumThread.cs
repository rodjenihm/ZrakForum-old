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
        public int ThreadId { get; set; }
        public DateTime StartedAt { get; set; }

        [Display(Name = "Naziv teme")]
        public string ThreadName { get; set; }

        [Display(Name = "Pokrenuo")]
        public string StartedBy { get; set; }
    }
}
