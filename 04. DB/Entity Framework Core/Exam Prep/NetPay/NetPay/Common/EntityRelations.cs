namespace NetPay.Common;

public static class EntityRelations
{
    public static class Household
    {
        public const int ContactPersonMinLength = 5;
        public const int ContactPersonMaxLength = 50;
        public const int EmailMinLength = 6;
        public const int EmailMaxLength = 80;
        public const int PhoneNumLength = 15;
        public const string PhoneNumRegex = @"^\+\d{3}/\d{3}-\d{6}$";
    }

    public static class Expense
    {
        public const int ExpenseMinLength = 5;
        public const int ExpenseMaxLength = 50;
        public const string AmountMinValue = "0.01";
        public const string AmountMaxValue = "100000.0";
        public const string AmountSqlType = "DECIMAL(8,2)";
    }

    public static class Service
    {
        public const int ServiceMinLength = 5;
        public const int ServiceMaxLength = 30;
    }

    public static class Supplier
    {
        public const int SupplierMinLength = 3;
        public const int SupplierMaxLength = 60;
    }
}
