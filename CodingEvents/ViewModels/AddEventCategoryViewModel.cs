using System.ComponentModel.DataAnnotations;


namespace CodingEvents.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required(ErrorMessage = "Please add category.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Category type must be between 3 and 20 characters.")]
        public string? Name { get; set; }
    }
}
