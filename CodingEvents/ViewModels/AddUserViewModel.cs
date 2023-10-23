using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "Username Required.")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "User name mist be between 3 and 12 characters long")]
        public string? UserName { get; set; }
        [Required]
        [StringLength (20, MinimumLength = 6)]
        public string? Email { get; set; }
    }
}
