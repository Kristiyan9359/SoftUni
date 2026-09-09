namespace RecipeSharingPlatform.ViewModels
{
    public class RecipeDeleteViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string AuthorId { get; set; } = null!;

        public string Author { get; set; } = null!;
    }
}
