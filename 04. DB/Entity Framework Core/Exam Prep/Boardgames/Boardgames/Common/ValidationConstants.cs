namespace Boardgames.Common;

public static class ValidationConstants
{
    //BoardGame
    public const int GameNameMinLength = 10;
    public const int GameNameMaxLength = 20;
    public const double GameRatingMinRange = 1;
    public const double GameRatingMaxRange = 10;
    public const int YearPublishedMinRange = 2018;
    public const int YearPublishedMaxRange = 2023;

    //Seller
    public const int SellerNameMinLength = 5;
    public const int SellerNameMaxLength = 20;
    public const int SellerAddressMinLength = 2;
    public const int SellerAddressMaxLength = 30;
    public const string SellerWebsiteRegex = @"(www\.[a-zA-Z0-9\-]{2,256}\.com)";

    //Creator
    public const int CreatorFirstNameMinLength = 2;
    public const int CreatorFirstNameMaxLength = 7;
    public const int CreatorLastNameMinLength = 2;
    public const int CreatorLastNameMaxLength = 7;
}