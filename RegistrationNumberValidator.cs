using System.Text.RegularExpressions;

public class RegistrationNumberValidator
{
    // Method to check if the registration number is in the valid format
    public static bool IsValidRegistrationNumber(string registrationNumber)
    {
        // Regular expression to match AAA111 or AAA 111 format (optional space)
        var regex = new Regex(@"^[A-Za-z]{3}\s?\d{3}$");
        return regex.IsMatch(registrationNumber);
    }

    // Method to format the registration number, automatically adding a space if needed
    public static string FormatRegistrationNumber(string registrationNumber)
    {
        // Remove any existing spaces for easier validation
        string cleanedRegistrationNumber = registrationNumber.Replace(" ", "");

        // Check if the registration number is valid without the space
        if (IsValidRegistrationNumber(cleanedRegistrationNumber))
        {
            // Insert a space after the first 3 characters and return the formatted registration number in uppercase
            return cleanedRegistrationNumber.Insert(3, " ").ToUpper();
        }
        else
        {
            // Throw an exception if the format is invalid
            throw new ArgumentException("Invalid registration number format. Please use 3 letters followed by 3 digits.");
        }
    }
}

