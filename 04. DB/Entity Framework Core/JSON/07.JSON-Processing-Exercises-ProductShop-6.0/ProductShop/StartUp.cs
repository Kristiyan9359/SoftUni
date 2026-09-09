namespace ProductShop;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;

public class StartUp
{
    public static void Main()
    {
        using ProductShopContext dbContext = new ProductShopContext();
        //dbContext.Database.EnsureDeleted();
        //dbContext.Database.EnsureCreated();

        //string jsonFileDirPath = Path
        //         .Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");

        //string jsonFileName = "products.json";

        //string jsonFileText = File
        //    .ReadAllText(jsonFileDirPath + jsonFileName);

        //string result = ImportCategoryProducts(dbContext, jsonFileText);

        string result = GetUsersWithProducts(dbContext);
        Console.WriteLine(result);
    }

    // IMPORT METHODS:

    // Problem 1
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        var usersToImport = new List<User>();
        var usersDto = JsonConvert.DeserializeObject<ImportUsersDto[]>(inputJson);

        if (usersDto != null)
        {

            foreach (ImportUsersDto userDto in usersDto)
            {
                if (!IsValid(userDto))
                {
                    continue;
                }

                bool isAgeValid =
                       TryParseNullableInt(userDto.Age, out int? age);

                if (!isAgeValid)
                {
                    continue;
                }

                User newUser = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = age
                };
                usersToImport.Add(newUser);
            }
            context.Users.AddRange(usersToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {usersToImport.Count}";
    }


    // Problem 2
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        var productsToImport = new List<Product>();
        var productsDto = JsonConvert.DeserializeObject<ImportProductsDto[]>(inputJson);

        if (productsDto != null)
        {
            foreach (ImportProductsDto productDto in productsDto)
            {
                if (!IsValid(productDto))
                {
                    continue;
                }
                bool isPriceValid = decimal
                       .TryParse(productDto.Price, out decimal priceVal);
                bool isSellerIdValid = int
                    .TryParse(productDto.SellerId, out int sellerIdVal);
                bool isBuyerIdValid =
                    TryParseNullableInt(productDto.BuyerId, out int? buyerIdVal);
                if (!isPriceValid || !isSellerIdValid || !isBuyerIdValid)
                {
                    continue;
                }
                Product newProduct = new Product()
                {
                    Name = productDto.Name,
                    Price = priceVal,
                    SellerId = sellerIdVal,
                    BuyerId = buyerIdVal,
                };
                productsToImport.Add(newProduct);
            }
            context.Products.AddRange(productsToImport);
            context.SaveChanges();
        }
        return $"Successfully imported {productsToImport.Count}";
    }


    // Problem 3

    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        var categoriesToImport = new List<Category>();
        var categories = JsonConvert.DeserializeObject<ImportCategoriesDto[]>(inputJson)
            .Where(c => c.Name != null)
            .ToList();

        foreach (var category in categories)
        {
            var newCategory = new Category()
            {
                Name = category.Name,
            };
            categoriesToImport.Add(newCategory);
        }
        context.Categories.AddRange(categoriesToImport);
        context.SaveChanges();
        return $"Successfully imported {categoriesToImport.Count}";
    }


    // Problem 4

    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        var categoryProductDtos = JsonConvert.DeserializeObject<List<ImportCategoriesProductsDto>>(inputJson);

        var validCategoryIds = context.Categories.Select(c => c.Id).ToHashSet();
        var validProductIds = context.Products.Select(p => p.Id).ToHashSet();

        var categoriesProductsToImport = categoryProductDtos
            .Where(cp => validCategoryIds.Contains(cp.CategoryId) && validProductIds.Contains(cp.ProductId))
            .Select(cp => new CategoryProduct
            {
                CategoryId = cp.CategoryId,
                ProductId = cp.ProductId
            })
            .Distinct()
            .ToList();

        context.CategoriesProducts.AddRange(categoriesProductsToImport);
        context.SaveChanges();

        return $"Successfully imported {categoriesProductsToImport.Count}";
    }



    // EXPORT METHODS:


    // Problem 5

    public static string GetProductsInRange(ProductShopContext context)
    {
        var productsInRange = context.Products
            .AsNoTracking()
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Select(p => new
            {
                name = p.Name,
                price = p.Price,
                seller = p.Seller.FirstName + " " + p.Seller.LastName
            })
            .ToArray();

        string jsonResult = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);
        return jsonResult;
    }


    // Problem 6


    public static string GetSoldProducts(ProductShopContext context)
    {
        var soldProducts = context.Users
             .AsNoTracking()
             .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
             .OrderBy(u => u.LastName)
             .ThenBy(u => u.FirstName)
             .Select(u => new
             {
                 firstName = u.FirstName,
                 lastName = u.LastName,
                 soldProducts = u.ProductsSold
                     .Where(p => p.BuyerId != null)
                     .Select(p => new
                     {
                         name = p.Name,
                         price = p.Price,
                         buyerFirstName = p.Buyer.FirstName,
                         buyerLastName = p.Buyer.LastName
                     })
                     .ToArray()
             })
             .ToArray();


        string jsonResult = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
        return jsonResult;
    }


    // Problem 7

    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .AsNoTracking()
            .OrderByDescending(c => c.CategoryProducts.Count)
            .Select(c => new
            {
                category = c.Name,
                productsCount = c.CategoryProducts.Count,
                averagePrice = c.CategoryProducts.Average(c => c.Product.Price),
                totalRevenue = c.CategoryProducts.Sum(c => c.Product.Price)
            })
            .ToArray();

        var result = categories.Select(x => new
        {
            category = x.category,
            productsCount = x.productsCount,
            averagePrice = x.averagePrice.ToString("F2"),
            totalRevenue = x.totalRevenue.ToString("F2")
        });


        string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
        return jsonResult;
    }


    // Problem 8

    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = context.Users
            .AsNoTracking()
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId != null))
            .Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                age = u.Age,
                soldProducts = new
                {
                    count = u.ProductsSold.Count(p => p.BuyerId != null),
                    products = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = Math.Round(p.Price, 2)
                        })
                        .ToList()
                }
            })
            .ToList();

        var result = new
        {
            usersCount = users.Count,
            users = users
        };

        return JsonConvert.SerializeObject(result, Formatting.Indented,
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
    }


    // HELPING METHOTDS

    private static bool TryParseNullableInt(string? input, out int? val)
    {
        int? outValue = null;
        if (input != null)
        {
            bool isInputValid = int
                .TryParse(input, out int ageVal);
            if (!isInputValid)
            {
                val = outValue;
                return false;
            }

            outValue = ageVal;
        }

        val = outValue;
        return true;
    }

    private static bool IsValid(object obj)
    {
        ValidationContext validationContext = new ValidationContext(obj);
        ICollection<ValidationResult> validationResults
            = new List<ValidationResult>();

        return Validator
            .TryValidateObject(obj, validationContext, validationResults);
    }
}