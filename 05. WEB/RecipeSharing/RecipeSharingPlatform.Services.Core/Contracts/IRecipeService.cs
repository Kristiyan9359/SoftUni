using RecipeSharingPlatform.ViewModels;

namespace RecipeSharingPlatform.Services.Core.Contracts
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeIndexViewModel>> GetAllRecipesAsync(string? userId);

        Task<RecipeIndexViewModel?> GetRecipeByIdAsync(int id);

        Task<RecipeDetailsViewModel> GetRecipesDetailsByIdAsync(int id);

        Task<bool> IsRecipeSavedAsync(int recipeId, string userId);

        Task<bool> IsRecipeAuthorAsync(int recipeId, string userId);

        Task<RecipeCreateViewModel> GetRecipeCreateViewModelAsync();

        Task AddRecipeAsync(RecipeCreateViewModel model, string authorId);

        Task<IEnumerable<RecipeFavoritesViewModel>> GetFavoriteRecipesAsync(string userId);

        Task SaveRecipeAsync(int id, string userId);

        Task RemoveRecipeAsync(int id, string userId);

        Task<RecipeEditViewModel> GetRecipeForEditAsync(int id, string userId);

        Task EditRecipeAsync(RecipeEditViewModel model, string userId);

        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

        Task DeleteRecipeAsync(int id, string userId);

        Task<RecipeDeleteViewModel> GetRecipeDeleteDetailsAsync(int id, string userId);

    }
}
