using System.Text.RegularExpressions;

namespace SnomedCtTools.Lib.Validation;


public static class SnomedCtValidator
{

    /// <summary>
    /// Checks if a Snomed Ct Code is valid.
    /// It should be :
    /// - 6 to 18 digits
    /// - All numerics (this method washes away whitespace anyways)
    /// - Passes the Verhoeff's dihedral check, which is checked by this 
    /// method internally.
    /// </summary>
    /// <param name="code">Input code</param>
    /// <returns>Boolean flag if the passed in Snomed Ct code is valid and passes Verhoeff's algorithm for error detection</returns>
    /// <remarks>The validation removes whitespace and checks that the length of the code is 6-18 in length. It 
    /// normalizes and removed whitespace. It also checks that the normalized code only contains positive digits 0-9.</remarks>
    public static bool IsValidSnomedCt(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            return false;
        }
        //normalize whitespace to allow flexibility concerning whitespace
        string normalizedCode = Regex.Replace(code, @"\s+", "");
        if (!normalizedCode.All(c => char.IsDigit(c) && byte.Parse(c.ToString()) >= 0 && byte.Parse(c.ToString()) <= 9))
        {
            return false;
        }

        if (normalizedCode.Length < 6 || normalizedCode.Length > 18)
        {
            return false;
        }

        bool isValid = VerhoeffValidator.IsValidVerhoeff(normalizedCode);
        return isValid;
    }

    /// <summary>
    /// Generates the Snomed Ct Control digit, where is the Verhoeff's checksum to be appended 
    /// to the code to act as a check-sum to guard against errors.
    /// The passed in code must only contain digits and be of length 6-18. Whitespace is washed away.
    /// The digits must only be positive digits 0-9.
    /// </summary>
    /// <param name="code">Input code</param>
    /// <returns>Verhoeff's checksum to be appended to the Snomed ct code. In case the input code is not valid Snomed ct code, null is returned instead</returns>
    public static string? GenerateSnomedCtCode(string code)
    {
        //normalize whitespace to allow flexibility concerning whitespace
        string normalizedCode = Regex.Replace(code, @"\s+", "");
        if (!normalizedCode.All(c => char.IsDigit(c) && byte.Parse(c.ToString()) >= 0 && byte.Parse(c.ToString()) <= 9))
        {
            return null;
        }
        char verhoeffControlDigit = VerhoeffValidator.GenerateVerhoeff(code);
        return code + verhoeffControlDigit;
    }

}


