namespace Cadastre.DataProcessor;

using Cadastre.Data;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using Cadastre.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using static Cadastre.Data.Enumerations.Enums;
using static Cadastre.Utilities.XmlSerializerWrapper;

public class Deserializer
{
    private const string ErrorMessage =
        "Invalid Data!";
    private const string SuccessfullyImportedDistrict =
        "Successfully imported district - {0} with {1} properties.";
    private const string SuccessfullyImportedCitizen =
        "Succefully imported citizen - {0} {1} with {2} properties.";

    public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
    {
        StringBuilder sb = new StringBuilder();

        ImportDistrictDtos[] districtDtos = XmlSerializerWrapper.Deserialize<ImportDistrictDtos[]>(xmlDocument, "Districts");
        ICollection<District> validDistricts = new List<District>();

        foreach (var disDto in districtDtos)
        {
            if (!IsValid(disDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }
            if (dbContext.Districts.Any(d => d.Name == disDto.Name))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            District district = new District()
            {
                Name = disDto.Name,
                PostalCode = disDto.PostalCode,
                Region = (Region)Enum.Parse(typeof(Region), disDto.Region)
            };

            foreach (var propDto in disDto.Properties)
            {
                if (!IsValid(propDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime acquisitionDate = DateTime
                    .ParseExact(propDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo
                    .InvariantCulture, DateTimeStyles.None);

                if (dbContext.Properties.Any(p => p.PropertyIdentifier == propDto.PropertyIdentifier) || district.Properties.Any(dp => dp.PropertyIdentifier == propDto.PropertyIdentifier))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (dbContext.Properties.Any(p => p.Address == propDto.Address) || district.Properties.Any(dp => dp.Address == propDto.Address))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Property property = new Property()
                {
                    PropertyIdentifier = propDto.PropertyIdentifier,
                    Area = propDto.Area,
                    Details = propDto.Details,
                    Address = propDto.Address,
                    DateOfAcquisition = acquisitionDate
                };

                district.Properties.Add(property);
            }
            validDistricts.Add(district);
            sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
        }
        dbContext.Districts.AddRange(validDistricts);
        dbContext.SaveChanges();
        return sb.ToString().TrimEnd();
    }

    public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
    {
        StringBuilder output = new StringBuilder();

        var citizensToImport = new List<Citizen>();

        var citizenDtos = JsonConvert.DeserializeObject<ImportCitizenDtos[]>(jsonDocument);

        if (citizenDtos != null)
        {
            foreach (var citizenDto in citizenDtos)
            {
                if (!IsValid(citizenDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var birthDate = DateTime
                    .ParseExact(citizenDto.BirthDate, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None);

                Citizen newCitizen = new Citizen()
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = birthDate,
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), 
                    citizenDto.MaritalStatus)
                };

                foreach (var property in citizenDto.Properties)
                {
                    PropertyCitizen propertyCitizen = new PropertyCitizen()
                    {
                        Citizen = newCitizen,
                        PropertyId = property
                    };
                   newCitizen.PropertiesCitizens.Add(propertyCitizen);
                }

                citizensToImport.Add(newCitizen);

                output.AppendLine(string.Format(SuccessfullyImportedCitizen, newCitizen.FirstName, newCitizen.LastName, newCitizen.PropertiesCitizens.Count));
            }
            dbContext.AddRange(citizensToImport);
            dbContext.SaveChanges();
        }
            return output.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}
