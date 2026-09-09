using RecipeSharing.Data.Models;
using RecipeSharingPlatform.GCommon;
using System.ComponentModel.DataAnnotations;

namespace RecipeSharingPlatform.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
    }
}
