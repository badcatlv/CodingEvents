using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name of event required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please give a description on the event")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 100 characters")]
        public string? Description { get; set; }

        [EmailAddress]
        public string? ContactEmail { get; set; }
    }
}
