namespace Boardgames.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Text;
using Boardgames.Data;
using Boardgames.Data.Models;
using Boardgames.DataProcessor.ImportDto;
using Newtonsoft.Json;
using static Boardgames.Data.Models.Enums.Enums;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCreator
        = "Successfully imported creator – {0} {1} with {2} boardgames.";

    private const string SuccessfullyImportedSeller
        = "Successfully imported seller - {0} with {1} boardgames.";

    public static string ImportCreators(BoardgamesContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        var creators = new List<Creator>();

        var creatorsDto = XmlSerializerWrapper.Deserialize<ImportCreatorsDto[]>(xmlString, "Creators");

        foreach (var creatorDto in creatorsDto)
        {
            if (!IsValid(creatorDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var creator = new Creator()
            {
                FirstName = creatorDto.FirstName,
                LastName = creatorDto.LastName,

            };

            foreach (var boardGameDto in creatorDto.Boardgames)
            {
                if (!IsValid(boardGameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var boardGame = new Boardgame()
                {
                    Name = boardGameDto.Name,
                    Rating = boardGameDto.Rating,
                    YearPublished = boardGameDto.YearPublished,
                    CategoryType = (CategoryType)boardGameDto.CategoryType,
                    Mechanics = boardGameDto.Mechanics
                };
                creator.Boardgames.Add(boardGame);
            }
            creators.Add(creator);
            sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
        }
        context.Creators.AddRange(creators);
        context.SaveChanges();
        return sb.ToString().TrimEnd();
    }

    public static string ImportSellers(BoardgamesContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        var sellersDtos = JsonConvert.DeserializeObject<ImportSellersDto[]>(jsonString);

        List<Seller> sellers = new List<Seller>();

        foreach (var sellerDto in sellersDtos)
        {
            if (!IsValid(sellerDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Seller seller = new Seller()
            {
                Name = sellerDto.Name,
                Address = sellerDto.Address,
                Country = sellerDto.Country,
                Website = sellerDto.Website,
            };

            foreach (int boardgameId in sellerDto.Boardgames.Distinct())
            {
                Boardgame boardgame = context.Boardgames.Find(boardgameId);
                if (boardgame == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                seller.BoardgamesSellers.Add(new BoardgameSeller()
                {
                    Boardgame = boardgame
                });
            }
            sellers.Add(seller);
            sb.AppendLine(String.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
        }
        context.Sellers.AddRange(sellers);
        context.SaveChanges();
        return sb.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}
