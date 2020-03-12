using System.ComponentModel.DataAnnotations;

namespace ZrakForum.Web.Models
{
    public class ThreadCreateDto
    {
        [Required(ErrorMessage = "Naziv teme je obavezan")]
        [StringLength(30, ErrorMessage = "Naziv teme ime mora imati najviše {1} karaktera")]
        [Display(Name = "Naziv teme")]
        public string Name { get; set; }
        public PostCreateDto Post { get; set; }
    }
}