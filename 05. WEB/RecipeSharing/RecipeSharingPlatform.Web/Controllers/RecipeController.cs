using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels;

namespace RecipeSharingPlatform.Web.Controllers
{
    public class RecipeController : BaseController
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string? userId = GetUserId();
            var recipes = await _recipeService.GetAllRecipesAsync(userId);

            return View(recipes);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var recipe = await _recipeService.GetRecipesDetailsByIdAsync(id);
            if (recipe == null)
            {
                if (User?.Identity?.IsAuthenticated == false)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index");
            }

            string? userId = GetUserId();
            recipe.IsAuthor = await _recipeService.IsRecipeAuthorAsync(recipe.Id, userId);
            recipe.IsSaved = await _recipeService.IsRecipeSavedAsync(recipe.Id, userId);

            return View(recipe);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            RecipeCreateViewModel model = await _recipeService.GetRecipeCreateViewModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await _recipeService.GetRecipeCreateViewModelAsync();
                return View(model);
            }

            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            await _recipeService.AddRecipeAsync(model, userId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            IEnumerable<RecipeFavoritesViewModel> models = await _recipeService.GetFavoriteRecipesAsync(userId);

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Save(int id)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            await _recipeService.SaveRecipeAsync(id, userId);

            var referer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
            {
                return Redirect(referer);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            await _recipeService.RemoveRecipeAsync(id, userId);
            return RedirectToAction("Favorites");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            try
            {
                var model = await _recipeService.GetRecipeForEditAsync(id, userId);
                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(RecipeEditViewModel model)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await _recipeService.GetAllCategoriesAsync();
                return View(model);
            }

            try
            {
                await _recipeService.EditRecipeAsync(model, userId);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }

            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var recipe = await _recipeService.GetRecipeDeleteDetailsAsync(id, userId);

            return View(recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            try
            {
                await _recipeService.DeleteRecipeAsync(id, userId);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}
