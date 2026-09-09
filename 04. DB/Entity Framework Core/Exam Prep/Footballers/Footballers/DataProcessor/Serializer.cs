namespace Footballers.DataProcessor;

using Data;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ExportDto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

public class Serializer
{
    public static string ExportCoachesWithTheirFootballers(FootballersContext context)
    {
        var coaches = context
            .Coaches
            .Where(c => c.Footballers.Any())
            .OrderByDescending(c => c.Footballers.Count)
            .ToArray()
            .Select(c => new ExportCoachesWithTheirFootballersDto()
            {
                CoachName = c.Name,
                FootballersCount = c.Footballers.Count,
                Footballers = c.Footballers
                .OrderBy(cf => cf.Name)
                .Select(cf => new ExportFootballersDto()
                {
                    Name = cf.Name,
                    Position = cf.PositionType.ToString()
                })
                .ToArray()
            })
            .ToArray();

        var result = XmlSerializerWrapper.Serialize(coaches, "Coaches");

        return result;
    }

    public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
    {
        var teams = context
          .Teams
          .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
          .ToArray()
          .Select(t => new
          {
              t.Name,
              Footballers = t.TeamsFootballers
                  .Where(tf => tf.Footballer.ContractStartDate >= date)
                  .ToArray()
                  .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                  .ThenBy(tf => tf.Footballer.Name)
                  .Select(tf => new
                  {
                      FootballerName = tf.Footballer.Name,
                      ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                      ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                      BestSkillType = tf.Footballer.BestSkillType.ToString(),
                      PositionType = tf.Footballer.PositionType.ToString()
                  })
                  .ToArray()
          })
          .OrderByDescending(t => t.Footballers.Length)
          .ThenBy(t => t.Name)
          .Take(5)
          .ToArray();

        return JsonConvert.SerializeObject(teams, Formatting.Indented);
    }
}

