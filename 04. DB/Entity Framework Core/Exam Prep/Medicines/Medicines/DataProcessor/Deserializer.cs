namespace Medicines.DataProcessor;

using Medicines.Data;
using Medicines.Data.Models;
using Medicines.DataProcessor.ImportDtos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using static Medicines.Data.Models.Enums.Enums;

public class Deserializer
{
    private const string ErrorMessage = "Invalid Data!";
    private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
    private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

    public static string ImportPatients(MedicinesContext context, string jsonString)
    {
        int counter = 0;

        StringBuilder sb = new StringBuilder();

        var patients = new List<Patient>();

        var patientDtos = JsonConvert.DeserializeObject<ImportPartientDto[]>(jsonString);

        foreach (var patientDto in patientDtos)
        {
            if (!IsValid(patientDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Patient patient = new Patient()
            {
                FullName = patientDto.FullName,
                AgeGroup = (AgeGroup)patientDto.AgeGroup,
                Gender = (Gender)patientDto.Gender,
            };

            foreach (var medicineId in patientDto.Medicines)
            {
                if (patient.PatientsMedicines.Any(x => x.MedicineId == medicineId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

               PatientMedicine patientMedicine = new PatientMedicine()
               {
                   Patient = patient,
                   MedicineId = medicineId
               };
                patient.PatientsMedicines.Add(patientMedicine);
            }
            counter += patient.PatientsMedicines.Count;
            patients.Add(patient);
            sb.AppendLine(string.Format(SuccessfullyImportedPatient,patient.FullName, patient.PatientsMedicines.Count));
        }
        context.Patients.AddRange(patients);
        context.SaveChanges();
        return sb.ToString().TrimEnd();
    }

    public static string ImportPharmacies(MedicinesContext context, string xmlString)
    {
        int medCounter = 0;

        StringBuilder sb = new StringBuilder();

        var pharmacies = new List<Pharmacy>();

        var pharmaciesDto = XmlSerializerWrapper.Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");


        foreach (var pharmacyDto in pharmaciesDto)
        {
            if (!IsValid(pharmacyDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Pharmacy pharmacy = new Pharmacy()
            {
                Name = pharmacyDto.Name,
                PhoneNumber = pharmacyDto.PhoneNumber,
                IsNonStop = bool.Parse(pharmacyDto.IsNonStop)
            };

            foreach (var medicineDto in pharmacyDto.Medicines)
            {
                if (!IsValid(medicineDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime medicineProductionDate;

                bool isProductionDateValid = DateTime
                    .TryParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out medicineProductionDate);

                if (!isProductionDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime medicineExpiryDate;

                bool isDateExpired = DateTime
                    .TryParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out medicineExpiryDate);

                if (!isDateExpired)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (medicineProductionDate >= medicineExpiryDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (pharmacy.Medicines.Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Medicine medicine = new Medicine()
                {
                    Name = medicineDto.Name,
                    Price = (decimal)medicineDto.Price,
                    Category = (Category)medicineDto.Category,
                    ProductionDate = medicineProductionDate,
                    ExpiryDate = medicineExpiryDate,
                    Producer = medicineDto.Producer
                };

                medCounter++;
                pharmacy.Medicines.Add(medicine);
            }
            pharmacies.Add(pharmacy);

            sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));

        }
        context.Pharmacies.AddRange(pharmacies);
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
