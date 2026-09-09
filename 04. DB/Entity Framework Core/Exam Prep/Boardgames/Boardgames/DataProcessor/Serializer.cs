namespace Boardgames.DataProcessor;

using Boardgames.Data;
using Boardgames.DataProcessor.ExportDto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

public class Serializer
{
    public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
    {
        var sellers = context
     .Sellers
     .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
     .ToArray()
     .Select(s => new
     {
         s.Name,
         s.Website,
         Boardgames = s.BoardgamesSellers
             .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
             .ToArray()
             .OrderByDescending(bs => bs.Boardgame.Rating)
             .ThenBy(bs => bs.Boardgame.Name)
             .Select(bs => new
             {
                 Name = bs.Boardgame.Name,
                 Rating = bs.Boardgame.Rating,
                 Mechanics = bs.Boardgame.Mechanics,
                 Category = bs.Boardgame.CategoryType.ToString()
             })
             .ToArray()
     })
     .OrderByDescending(s => s.Boardgames.Length)
     .ThenBy(s => s.Name)
     .Take(5)
     .ToArray();

        return JsonConvert.SerializeObject(sellers, Formatting.Indented);
    }

    public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
    {
        const string xmlRootName = "Creators";

        var creators = context
            .Creators
            .Include(c => c.Boardgames)
            .Where(c => c.Boardgames.Count > 0)
            .AsNoTracking()
            .OrderByDescending(c => c.Boardgames.Count)
            .ThenBy(c => c.FirstName)
            .ToArray()
            .Select(c => new ExportCreatorDto
            {
                Name = $"{c.FirstName} {c.LastName}",
                BoardgamesCount = c.Boardgames.Count,
                Boardgames = c.Boardgames
                    .OrderBy(bg => bg.Name)
                    .Select(bg => new ExportBoardgamesDto
                    {
                        Name = bg.Name,
                        YearPublished = bg.YearPublished
                    })
                    .ToArray()
            })
            .ToArray();

        var result = XmlSerializerWrapper.Serialize(creators, xmlRootName);

        return result;
    }
}