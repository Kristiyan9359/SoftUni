
int period = int.Parse(Console.ReadLine());
int doctors = 7;
int treatedPatients = 0;
int untreatedPatients = 0;

for (int days = 1; days <= period; days++)
{
    int patients = int.Parse(Console.ReadLine());

    if (days % 3 == 0 && untreatedPatients > treatedPatients)
    {
        doctors++;
    }
    if (patients <= doctors)
    {
        treatedPatients += patients;
    }
    else
    {
        treatedPatients += doctors;
        untreatedPatients += patients - doctors;
    }
}

Console.WriteLine($"Treated patients: {treatedPatients}.");
Console.WriteLine($"Untreated patients: {untreatedPatients}.");