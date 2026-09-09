using RecipeSharingPlatform.GCommon;
using System.ComponentModel.DataAnnotations;

namespace RecipeSharingPlatform.ViewModels
{
    public class RecipeCreateViewModel
    {
        [Required]
        [StringLength(ValidationConstants.RecipeTitleMaxLength, MinimumLength = ValidationConstants.RecipeTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.RecipeInstructionsMaxLength, MinimumLength = ValidationConstants.RecipeInstructionsMinLength)]
        public string Instructions { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string CreatedOn { get; set; } = null!;

        [Required]
        [Range(ValidationConstants.CategoryIdMinValue, ValidationConstants.CategoryIdMaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel>? Categories { get; set; }
    }
}
