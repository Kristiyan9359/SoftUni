namespace Invoices.Data.Common;

public static class EntityRelations
{
    public static class Product
    {
        public const int ProductMinLength = 9;
        public const int ProductMaxLength = 30;
        public const double ProductPriceMinRange = 5.00;
        public const double ProductPriceMaxRange = 1000.00;
    }

    public static class Address
    {
        public const int StreetNameMinLength = 10;
        public const int StreetNameMaxLength = 20;
        public const int CityNameMinLength = 5;
        public const int CityNameMaxLength = 15;
        public const int CountryNameMinLength = 5;
        public const int CountryNameMaxLength = 15;
    }

    public static class Invoice
    {
        public const int NumberMinRange = 1000000000;
        public const int NumberMaxRange = 1500000000;
    }

    public static class Client
    {
        public const int ClientNameMinLength = 10;
        public const int ClientNameMaxLength = 25;
        public const int ClientNumberVatMinLength = 10;
        public const int ClientNumberVatMaxLength = 15;
    }
}
