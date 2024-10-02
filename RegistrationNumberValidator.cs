using System.Text.RegularExpressions;

public class RegistrationNumberValidator
{
    public static bool IsValidRegistrationNumber(string registrationNumber)
    {
        // Regular expression to match AAA111 or AAA 111 format
        var regex = new Regex(@"^[A-Za-z]{3}\s?\d{3}$");
        return regex.IsMatch(registrationNumber);
    }
}
