using _03.Telephony.Contracts;

namespace _03.Telephony.Models;

public class Stationaryphone : ICallable
{
    public string Call(string phoneNumber)
    {
        if (!ValidatePhoneNumber(phoneNumber))
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Dialing... {phoneNumber}";
    }

    private bool ValidatePhoneNumber(string phoneNumber)
        => phoneNumber.All(c => char.IsDigit(c));
}

