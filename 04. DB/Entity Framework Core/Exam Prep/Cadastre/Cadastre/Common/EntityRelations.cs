namespace Cadastre.Common;

public static class EntityRelations
{
    public static class District
    {
        public const int DistrictMinLength = 2;
        public const int DistrictMaxLength = 80;
        public const string DistrictPostalCodeRegex = @"^[A-Z]{2}-\d{5}$";
    }

    public static class Property
    {
        public const int PropertyIdentifierMinLength = 16;
        public const int PropertyIdentifierMaxLength = 20;
        public const int DetailsMinLength = 5;
        public const int DetailsMaxLength = 500;
        public const int PropertyAddressMinLength = 5;
        public const int PropertyAddressMaxLength = 200;
    }

    public static class Citizen
    {
        public const int CitizenFirstNameMinLength = 2;
        public const int CitizenFirstNameMaxLength = 30;
        public const int CitizenLastNameMinLength = 2;
        public const int CitizenLastNameMaxLength = 30;
    }
}
