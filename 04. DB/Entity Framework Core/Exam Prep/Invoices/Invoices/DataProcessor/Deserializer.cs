namespace Invoices.DataProcessor;

using Invoices.Data;
using Invoices.Data.Models;
using Invoices.DataProcessor.ImportDto;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedClients
        = "Successfully imported client {0}.";

    private const string SuccessfullyImportedInvoices
        = "Successfully imported invoice with number {0}.";

    private const string SuccessfullyImportedProducts
        = "Successfully imported product - {0} with {1} clients.";


    public static string ImportClients(InvoicesContext context, string xmlString)
    {
        string XmlRootName = "Clients";

        StringBuilder sb = new StringBuilder();

        var clients = new List<Client>();

        var clientsDto = XmlSerializerWrapper.Deserialize<ImportClientsDto[]>(xmlString, XmlRootName);

        foreach (var clientDto in clientsDto)
        {
            if (!IsValid(clientDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Client client = new Client()
            {
                Name = clientDto.Name,
                NumberVat = clientDto.NumberVat
            };

            foreach (var addressDto in clientDto.Addresses)
            {
                if (!IsValid(addressDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Address address = new Address()
                {
                    StreetName = addressDto.StreetName,
                    StreetNumber = addressDto.StreetNumber,
                    PostCode = addressDto.PostCode,
                    City = addressDto.City,
                    Country = addressDto.Country
                };
                client.Addresses.Add(address);
            }
            clients.Add(client);
            sb.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
        }
        context.AddRange(clients);
        context.SaveChanges();
        return sb.ToString().TrimEnd();
    }


    public static string ImportInvoices(InvoicesContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        var invoices = new List<Invoice>();

        var invoicesDto = JsonConvert.DeserializeObject<ImportInvoicesDto[]>(jsonString);

        foreach (var invoiceDto in invoicesDto)
        {
            if (!IsValid(invoiceDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (invoiceDto.DueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture) || invoiceDto.IssueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Invoice invoice = new Invoice()
            {
                Number = invoiceDto.Number,
                IssueDate = invoiceDto.IssueDate,
                DueDate = invoiceDto.DueDate,
                Amount = invoiceDto.Amount,
                CurrencyType = invoiceDto.CurrencyType,
                ClientId = invoiceDto.ClientId
            };

            if (invoice.IssueDate >= invoice.DueDate)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            invoices.Add(invoice);
            sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
        }
        context.AddRange(invoices);
        context.SaveChanges();
        return sb.ToString().TrimEnd();
    }

    public static string ImportProducts(InvoicesContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        var products = new List<Product>();

        var productsDto = JsonConvert.DeserializeObject<ImportProductsDto[]>(jsonString);

        foreach (var productDto in productsDto)
        {
            if (!IsValid(productDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Product product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryType = productDto.CategoryType
            };

            foreach (var clientId in productDto.Clients.Distinct())
            {
                Client c = context.Clients.Find(clientId);
                if (c == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                product.ProductsClients.Add(new ProductClient()
                {
                    Client = c
                });
            }
            products.Add(product);
            sb.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
        }
        context.AddRange(products);
        context.SaveChanges();
        return sb.ToString().TrimEnd();
    }

    public static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}
