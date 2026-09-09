namespace NetPay.DataProcessor;

using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Text.Json.Nodes;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data format!";
    private const string DuplicationDataMessage = "Error! Data duplicated.";
    private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
    private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

    public static string ImportHouseholds(NetPayContext context, string xmlString)
    {
        const string xmlRootName = "Households";

        StringBuilder output = new StringBuilder();

        var householdsToImport = new List<Household>();

        var householdDtos = XmlSerializerWrapper.Deserialize<ImportHouseholdDto[]>(xmlString, xmlRootName);

        if (householdDtos != null)
        {
            foreach (var householdDto in householdDtos)
            {
                if (!IsValid(householdDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var householdExists = context
                    .Households
                    .Any(h => h.ContactPerson == householdDto.ContactPerson ||
                    h.PhoneNumber == householdDto.PhoneNumber ||
                    h.Email == householdDto.Email);

                var householdAlreadyImportet = householdsToImport
                     .Any(h => h.ContactPerson == householdDto.ContactPerson ||
                    h.PhoneNumber == householdDto.PhoneNumber ||
                    h.Email == householdDto.Email);

                if (householdAlreadyImportet || householdExists)
                {
                    output.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Household newHousehold = new Household()
                {
                    ContactPerson = householdDto.ContactPerson,
                    Email = householdDto.Email,
                    PhoneNumber = householdDto.PhoneNumber
                };
                householdsToImport.Add(newHousehold);
                output.AppendLine(String.Format(SuccessfullyImportedHousehold, newHousehold.ContactPerson));
            }
            context.AddRange(householdsToImport);
            context.SaveChanges();
        }
        return output.ToString().TrimEnd();
    }

    public static string ImportExpenses(NetPayContext context, string jsonString)
    {
        StringBuilder output = new StringBuilder();

        var expensesToImport = new List<Expense>();

        var expenseDtos = JsonConvert.DeserializeObject<ImportExpenseDto[]>(jsonString);

        if (expenseDtos != null)
        {
            foreach (var expenseDto in expenseDtos)
            {
                if (!IsValid(expenseDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                bool householdExists = context
                     .Households
                     .Any(h => h.Id == expenseDto.HouseholdId!.Value);
                bool serviceExists = context
                    .Services
                    .Any(s => s.Id == expenseDto.ServiceId!.Value);

                if (!householdExists || !serviceExists)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDueDateValid = DateTime
                       .TryParseExact(expenseDto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out DateTime dueDateVal);
                bool isPaymentStatusValid = Enum
                    .TryParse<PaymentStatus>(expenseDto.PaymentStatus, out PaymentStatus paymentStatusVal);
                if ((!isDueDateValid) ||
                    (!isPaymentStatusValid))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Expense newExpense = new Expense()
                {
                    ExpenseName = expenseDto.ExpenseName,
                    Amount = expenseDto.Amount!.Value,
                    DueDate = dueDateVal,
                    PaymentStatus = paymentStatusVal,
                    HouseholdId = expenseDto.HouseholdId!.Value,
                    ServiceId = expenseDto.ServiceId!.Value,
                };

                expensesToImport.Add(newExpense);

                output.AppendLine(String.Format(SuccessfullyImportedExpense,
                    expenseDto.ExpenseName, expenseDto.Amount.Value.ToString("F2")));
            }
            context.Expenses.AddRange(expensesToImport);
            context.SaveChanges();
        }
        return output.ToString().TrimEnd();
    }

    public static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

        foreach (var result in validationResults)
        {
            string currvValidationMessage = result.ErrorMessage;
        }

        return isValid;
    }
}
