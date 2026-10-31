using FluentAssertions;
using NUnit.Framework;
using SnomedCtTools.Lib.Validation;

namespace SnomedCtTools.Tests.Validation;


[TestFixture]
public class VerhoeffValidatorTests
{

    [TestCase("90560007")]
    [TestCase("67148009")]
    [TestCase("80146002")]
    public void IsValidVerhoeff_ReturnsTrue_ForValidSnomedCtIdentifier(string identifier)
    {
        VerhoeffValidator.IsValidVerhoeff(identifier)
            .Should()
            .BeTrue();
    }

    [TestCase("90560008")]
    [TestCase("67148008")]
    [TestCase("80146003")]
    public void IsValidVerhoeff_ReturnsFalse_WhenCheckDigitIsChanged(string identifier)
    {
        VerhoeffValidator.IsValidVerhoeff(identifier)
            .Should()
            .BeFalse();
    }

    [TestCase("90506007")]
    [TestCase("67184009")]
    [TestCase("81046002")]
    public void IsValidVerhoeff_ReturnsFalse_WhenAdjacentDigitsAreSwapped(string identifier)
    {
        VerhoeffValidator.IsValidVerhoeff(identifier)
            .Should()
            .BeFalse();
    }

    [TestCase("2363")]
    [TestCase("123451")]
    public void IsValidVerhoeff_ReturnsTrue_ForKnownVerhoeffExamples(string number)
    {
        VerhoeffValidator.IsValidVerhoeff(number)
            .Should()
            .BeTrue();
    }

}