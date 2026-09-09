using Microsoft.EntityFrameworkCore;
using RecipeSharing.Data.Models;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Data.Models;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels;

namespace RecipeSharingPlatform.Services.Core
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeSharingDbContext _context;

        public RecipeService(RecipeSharingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecipeIndexViewModel>> GetAllRecipesAsync(string? userId)
        {
            return await _context.Recipes
                .Where(r => !r.IsDeleted)
                .Include(r => r.Category)
                .Include(r => r.UsersRecipes)
                .Select(r => new RecipeIndexViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    ImageUrl = r.ImageUrl,
                    Category = r.Category.Name,
                    SavedCount = r.UsersRecipes.Count,
                    IsAuthor = userId != null && r.AuthorId == userId,
                    IsSaved = userId != null && r.UsersRecipes.Any(ur => ur.RecipeId == r.Id && ur.UserId == userId)
                })
                .ToListAsync();
        }

        public async Task<RecipeIndexViewModel?> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.UsersRecipes)
                .Where(r => r.Id == id)
                .Select(r => new RecipeIndexViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    ImageUrl = r.ImageUrl,
                    Category = r.Category.Name,
                    SavedCount = r.UsersRecipes.Count,
                    IsAuthor = false,
                    IsSaved = false
                })
                .FirstOrDefaultAsync();
        }

        public async Task<RecipeDetailsViewModel> GetRecipesDetailsByIdAsync(int id)
        {
            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Author)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null)
            {
                throw new InvalidOperationException("Destination not found");
            }
            return new RecipeDetailsViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                ImageUrl = recipe.ImageUrl,
                Instructions = recipe.Instructions,
                Category = recipe.Category.Name,
                Author = recipe.Author.UserName,
                CreatedOn = recipe.CreatedOn,
                IsAuthor = false,
                IsSaved = false
            };
        }

        public async Task<bool> IsRecipeAuthorAsync(int recipeId, string userId)
        {
            return await _context.Recipes
                .AnyAsync(r => r.Id == recipeId && r.AuthorId == userId);
        }

        public async Task<bool> IsRecipeSavedAsync(int recipeId, string userId)
        {
            return await _context.UsersRecipes
                .AnyAsync(ur => ur.RecipeId == recipeId && ur.UserId == userId);
        }

        public async Task<RecipeCreateViewModel> GetRecipeCreateViewModelAsync()
        {
            IEnumerable<CategoryViewModel> categories = await _context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            RecipeCreateViewModel model = new RecipeCreateViewModel
            {
                Categories = categories,
                CreatedOn = DateTime.UtcNow.ToString("yyyy-MM-dd")
            };

            return model;
        }

        public async Task AddRecipeAsync(RecipeCreateViewModel model, string authorId)
        {
            if (!DateTime.TryParseExact(model.CreatedOn, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var publishedDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            var recipe = new Recipe
            {
                Title = model.Title,
                Instructions = model.Instructions,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                AuthorId = authorId,
                CreatedOn = publishedDate
            };

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RecipeFavoritesViewModel>> GetFavoriteRecipesAsync(string userId)
        {
            return await _context.UsersRecipes
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Recipe)
                .Select(ur => new RecipeFavoritesViewModel
                {
                    Id = ur.Recipe.Id,
                    Title = ur.Recipe.Title,
                    ImageUrl = ur.Recipe.ImageUrl,
                    Category = ur.Recipe.Category.Name
                })
                .ToListAsync();
        }

        public async Task SaveRecipeAsync(int id, string userId)
        {
            if (await _context.UsersRecipes.AnyAsync(ur => ur.UserId == userId && ur.RecipeId == id))
            {
                return;
            }

            var userRecipe = new UserRecipe
            {
                RecipeId = id,
                UserId = userId
            };

            await _context.UsersRecipes.AddAsync(userRecipe);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRecipeAsync(int id, string userId)
        {
            var userRecipe = await _context.UsersRecipes
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RecipeId == id);

            if (userRecipe == null)
            {
                return;
            }

            _context.UsersRecipes.Remove(userRecipe);
            await _context.SaveChangesAsync();
        }

        public async Task<RecipeEditViewModel> GetRecipeForEditAsync(int id, string userId)
        {
            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

            if (recipe == null)
            {
                throw new ArgumentException("Recipe not found.");
            }

            if (recipe.AuthorId != userId)
            {
                throw new UnauthorizedAccessException("You are not the author of this recipe.");
            }

            return new RecipeEditViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Instructions = recipe.Instructions,
                ImageUrl = recipe.ImageUrl,
                CreatedOn = recipe.CreatedOn.ToString("yyyy-MM-dd"),
                CategoryId = recipe.CategoryId,
                Categories = await _context.Categories
                    .Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToListAsync()
            };
        }


        public async Task EditRecipeAsync(RecipeEditViewModel model, string userId)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == model.Id && !r.IsDeleted);

            if (recipe == null || recipe.AuthorId != userId)
            {
                throw new UnauthorizedAccessException("You are not authorized to edit this recipe.");
            }

            recipe.Title = model.Title;
            recipe.Instructions = model.Instructions;
            recipe.ImageUrl = model.ImageUrl;
            recipe.CreatedOn = DateTime.Parse(model.CreatedOn);
            recipe.CategoryId = model.CategoryId;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task DeleteRecipeAsync(int id, string userId)
        {
            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

            if (recipe == null)
            {
                throw new ArgumentException("Recipe not found.");
            }

            if (recipe.AuthorId != userId)
            {
                throw new UnauthorizedAccessException("You are not authorized to delete this recipe.");
            }

            recipe.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<RecipeDeleteViewModel> GetRecipeDeleteDetailsAsync(int id, string userId)
        {
            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Author)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

            if (recipe == null)
            {
                throw new ArgumentException("Recipe not found.");
            }

            if (recipe.AuthorId != userId)
            {
                throw new UnauthorizedAccessException("You are not the author of this recipe.");
            }

            return new RecipeDeleteViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                AuthorId = recipe.AuthorId,
                Author = recipe.Author.UserName
            };
        }

    }
}
