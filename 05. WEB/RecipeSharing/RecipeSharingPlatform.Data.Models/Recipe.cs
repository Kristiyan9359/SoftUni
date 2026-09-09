using Microsoft.AspNetCore.Identity;
using RecipeSharingPlatform.Data.Models;
using RecipeSharingPlatform.GCommon;
using System.ComponentModel.DataAnnotations;

namespace RecipeSharing.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.RecipeTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.RecipeInstructionsMaxLength)]
        public string Instructions { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public string AuthorId { get; set; } = null!;
        public virtual IdentityUser Author { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<UserRecipe> UsersRecipes { get; set; } = new HashSet<UserRecipe>();
    }
}
