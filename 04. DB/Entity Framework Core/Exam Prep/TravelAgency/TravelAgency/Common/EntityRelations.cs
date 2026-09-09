using System.Text.RegularExpressions;

namespace TravelAgency.Common;

public static class EntityRelations
{
    // Customer
    public const int CustomerFullNameMaxLength = 60;
    public const int CustomerFullNameMinLength = 4;
    public const int CustomerEmailMaxLength = 50;
    public const int CustomerEmailMinLength = 6;
    public const string CustomerPhoneNumber = @"^\+\d{12}$";

    // Guide 
    public const int GuideFullNameMaxLength = 60;
    public const int GuideFullNameMinLength = 4;

    // TourPackage
    public const int TourPackageNameMaxLength = 40;
    public const int TourPackageNameMinLength = 2;
    public const int TourPackageDescriptionMaxLength = 200;
}
