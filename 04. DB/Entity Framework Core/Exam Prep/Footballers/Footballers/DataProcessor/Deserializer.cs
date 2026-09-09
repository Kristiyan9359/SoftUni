namespace Footballers.DataProcessor;

using Castle.Components.DictionaryAdapter;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Footballers.Data;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCoach
        = "Successfully imported coach - {0} with {1} footballers.";

    private const string SuccessfullyImportedTeam
        = "Successfully imported team - {0} with {1} footballers.";

    public static string ImportCoaches(FootballersContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        var coaches = new List<Coach>();

        var coachesDto = XmlSerializerWrapper.Deserialize<ImportCoachesDto[]>(xmlString, "Coaches");

        foreach (var coachDto in coachesDto)
        {
            if (!IsValid(coachDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            string nationality = coachDto.Nationality;
            bool isValidNationality = string.IsNullOrEmpty(nationality);

            if (isValidNationality)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var coach = new Coach()
            {
                Name = coachDto.Name,
                Nationality = coachDto.Nationality
            };

            foreach (var footballerDto in coachDto.Footballers)
            {
                if (!IsValid(footballerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime footballerContractStartDate;
                bool isFootballerContractStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out footballerContractStartDate);
                if (!isFootballerContractStartDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime footballerContractEndDate;
                bool isFootballerContractEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out footballerContractEndDate);
                if (!isFootballerContractEndDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (footballerContractStartDate >= footballerContractEndDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var footballer = new Footballer()
                {
                    Name = footballerDto.Name,
                    ContractStartDate = footballerContractStartDate,
                    ContractEndDate = footballerContractEndDate,
                    BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                    PositionType = (PositionType)footballerDto.PositionType
                };
                coach.Footballers.Add(footballer);
            }
            coaches.Add(coach);
            sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
        }
        context.Coaches.AddRange(coaches);
        context.SaveChanges();
        return sb.ToString().TrimEnd();
    }

    public static string ImportTeams(FootballersContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        var teams = new List<Team>();

        var teamsDto = JsonConvert.DeserializeObject<ImportTeamsDto[]>(jsonString);

        foreach (var teamDto in teamsDto)
        {
            if (!IsValid(teamDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Team team = new Team()
            {
                Name = teamDto.Name,
                Nationality = teamDto.Nationality,
                Trophies = teamDto.Trophies,
            };

            if (team.Trophies == 0)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            foreach (int footballerId in teamDto.Footballers.Distinct())
            {
                Footballer f = context.Footballers.Find(footballerId);
                if (f == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                team.TeamsFootballers.Add(new TeamFootballer()
                {
                    Footballer = f
                });
            }
            teams.Add(team);
            sb.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
        }
        context.Teams.AddRange(teams);
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
