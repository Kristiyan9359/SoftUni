namespace P02_FootballBetting.Common;

public static class EntityValidations
{
    public static class Team
    {
        /// <summary>
        /// Client specification req. 1231521312 - Max length for Team Name
        /// </summary>
        public const int NameMaxLength = 100;

        public const int LogoUrlMaxLength = 2048;

        public const int InitialsMaxLength = 5;

        public const string BudgetColumnType = "DECIMAL(13,5)";
    }

    public static class Color
    {
        public const int NameMaxLength = 30;
    }

    public static class Town
    {
        public const int NameMaxLength = 85;
    }

    public static class Country
    {
        public const int NameMaxLength = 56;
    }

    public static class Player
    {
        public const int NameMaxLength = 60;
    }

    public static class Position
    {
        public const int NameMaxLength = 30;
    }

    public static class Game
    {
        public const string BetRateColumnType = "DECIMAL(8,3)";
        public const int ResultMaxLength = 7;
    }

    public static class Bet
    {
        public const string AmountColumnType = "DECIMAL(12,5)";
    }

    public static class User
    {
        /// <summary>
        /// Max length for Username (unique, short identifier)
        /// </summary>
        public const int UsernameMaxLength = 30;

        /// <summary>
        /// Max length for full Name
        /// </summary>
        public const int NameMaxLength = 80;

        /// <summary>
        /// Max length for Password hash or encrypted string
        /// </summary>
        public const int PasswordMaxLength = 512;

        /// <summary>
        /// Max length for Email (standard max for email field)
        /// </summary>
        public const int EmailMaxLength = 320;

        /// <summary>
        /// Column type for Balance (money-like decimal)
        /// </summary>
        public const string BalanceColumnType = "DECIMAL(13,5)";
    }
}
