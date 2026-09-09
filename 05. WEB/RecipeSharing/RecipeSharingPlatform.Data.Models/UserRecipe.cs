using Microsoft.AspNetCore.Identity;
using RecipeSharing.Data.Models;

namespace RecipeSharingPlatform.Data.Models
{
    public class UserRecipe
    {
        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
