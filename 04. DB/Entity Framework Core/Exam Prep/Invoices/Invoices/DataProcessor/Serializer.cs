namespace Invoices.DataProcessor;

using AutoMapper.QueryableExtensions;
using Invoices.Data;
using Invoices.Data.Models;
using Invoices.DataProcessor.ExportDto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Xml.Serialization;
using static Invoices.Data.XmlSerializerWrapper;

public class Serializer
{
    public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
    {
        throw new NotImplementedException();
    }

    public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
    {
        var products = context
            .Products
            .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
            .ToArray()
            .Select(p => new
            {
                p.Name,
                p.Price,
                Category = p.CategoryType.ToString(),
                Clients = p.ProductsClients
                    .Where(pc => pc.Client.Name.Length >= nameLength)
                    .ToArray()
                    .OrderBy(pc => pc.Client.Name)
                    .Select(pc => new
                    {
                        Name = pc.Client.Name,
                        NumberVat = pc.Client.NumberVat,
                    })
                    .ToArray()
            })
            .OrderByDescending(p => p.Clients.Length)
            .ThenBy(p => p.Name)
            .Take(5)
            .ToArray();

        return JsonConvert.SerializeObject(products, Formatting.Indented);
    }
}