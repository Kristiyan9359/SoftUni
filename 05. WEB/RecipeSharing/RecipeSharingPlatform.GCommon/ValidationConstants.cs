namespace RecipeSharingPlatform.GCommon
{
    public class ValidationConstants
    {
        // Recipe
        public const int RecipeTitleMinLength = 3;
        public const int RecipeTitleMaxLength = 80;

        public const int RecipeInstructionsMinLength = 10;
        public const int RecipeInstructionsMaxLength = 1000;

        // Category (optional - assuming you'll use it)
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 20;
        public const int CategoryIdMinValue = 1;
        public const int CategoryIdMaxValue = 6;
    }
}
