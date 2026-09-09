namespace RecipeSharingPlatform.ViewModels
{
    public class RecipeFavoritesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
