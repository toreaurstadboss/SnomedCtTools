namespace SnomedCtTools.Lib.Validation;

/// <summary>
/// Validates numeric identifiers using the Verhoeff check digit algorithm.
/// </summary>
public static class VerhoeffValidator
{
    /// <summary>
    /// Checks whether a number has a valid Verhoeff check digit.
    /// </summary>
    /// <param name="number">The numeric identifier, including its check digit.</param>
    /// <returns><see langword="true" /> when the number passes the Verhoeff check.</returns>
    public static bool IsValidVerhoeff(string code)
    {
        int checksum = CalculateChecksum(code);
        return checksum == 0;
    }  

    /// <summary>
    /// Generates the Verhoeff digit, which is the check digit to be appended to code
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static char GenerateVerhoeff(string code)
    {
        string normalizedCode = code + "0";
        int checkSum = CalculateChecksum(normalizedCode);
        string checkDigit = J[checkSum].ToString();
        return checkDigit[0];
    }

    private static readonly byte[,] D =
    {
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
        { 1, 2, 3, 4, 0, 6, 7, 8, 9, 5 },
        { 2, 3, 4, 0, 1, 7, 8, 9, 5, 6 },
        { 3, 4, 0, 1, 2, 8, 9, 5, 6, 7 },
        { 4, 0, 1, 2, 3, 9, 5, 6, 7, 8 },
        { 5, 9, 8, 7, 6, 0, 4, 3, 2, 1 },
        { 6, 5, 9, 8, 7, 1, 0, 4, 3, 2 },
        { 7, 6, 5, 9, 8, 2, 1, 0, 4, 3 },
        { 8, 7, 6, 5, 9, 3, 2, 1, 0, 4 },
        { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }
    };

    private static readonly byte[,] P =
    {
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
        { 1, 5, 7, 6, 2, 8, 3, 0, 9, 4 },
        { 5, 8, 0, 3, 7, 9, 6, 1, 4, 2 },
        { 8, 9, 1, 6, 0, 4, 3, 5, 2, 7 },
        { 9, 4, 5, 3, 1, 2, 6, 8, 7, 0 },
        { 4, 2, 8, 6, 5, 7, 3, 9, 0, 1 },
        { 2, 7, 9, 3, 8, 0, 6, 4, 1, 5 },
        { 7, 0, 4, 6, 9, 1, 3, 2, 5, 8 }
    };

    private static readonly int[] J =
    {
        0,4,3,2,1,5,6,7,8,9
    };

    private static byte CalculateChecksum(string code)
    {
        byte[] digits = code
                    .Select(character => byte.Parse(character.ToString()))
                    .Reverse()
                    .ToArray();
        byte checksum = 0;

        for (int index = 0; index < digits.Length; index++)
        {
            checksum = D[checksum, P[index % 8, digits[index]]];
        }
        return checksum;
    }

}