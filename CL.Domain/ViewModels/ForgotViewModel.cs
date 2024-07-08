using System.ComponentModel.DataAnnotations;


namespace GetAuthentication.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
