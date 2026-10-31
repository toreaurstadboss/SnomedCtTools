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
    /// <param name="code"></param>
    /// <returns></returns>
    public static bool IsValidSnomedCt(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            return false;
        }
        //normalize whitespace to allow flexibility concerning whitespace
        string normalizedCode = Regex.Replace(code, @"\s+", "");
        if (!normalizedCode.All(c => char.IsDigit(c)))
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

}


