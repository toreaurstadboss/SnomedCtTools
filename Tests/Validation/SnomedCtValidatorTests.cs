using FluentAssertions;
using NUnit.Framework;
using SnomedCtTools.Lib.Validation;

namespace SnomedCtTools.Tests.Validation
{

    [TestFixture]
    public class SnomedCtValidatorTests
    {

        [Test]
        [TestCase("44054006", true, Description = "diabetes type 2")]
        [TestCase("440540006", false, Description = "not a snomed ct code")]
        [TestCase("67148009", true, Description = "Podagra")]
        [TestCase("671480091", false, Description = "not a snomed ct code")]
        public void SnomedCtValidationCheckForWellknownDiseases(string code, bool expected)
        {
            SnomedCtValidator.IsValidSnomedCt(code).Should().Be(expected);
        }

        [Test]
        [TestCase("24700007", true)]
        [TestCase("2470", false)]
        [TestCase("2470000000000000000000000000007", false)]
        public void SnomedCtValidationChecksLengthCorrect(string code, bool expected)
        {
            SnomedCtValidator.IsValidSnomedCt(code).Should().Be(expected);
        }

        [Test]
        [TestCase("24700007", true)]
        [TestCase(" 24700007", true)]
        [TestCase("24700007 ", true)]
        [TestCase("2470 0007  ", true)]
        [TestCase("2  470 00  07  ", true)]
        public void SnomedCtValidationAcceptsWhiteSpace(string code, bool expected)
        {
            SnomedCtValidator.IsValidSnomedCt(code).Should().Be(expected);
        }

        [Test]
        [TestCase("24700007", true)]
        [TestCase("k24700007", false)]
        [TestCase("24700007#", false)]
        [TestCase("2470@k0007kk", false)]
        [TestCase("2kk3k#@!470###00kk07ll", false)]
        public void SnomedCtValidationCheckIlleagalChars(string code, bool expected)
        {
            SnomedCtValidator.IsValidSnomedCt(code).Should().Be(expected);
        }

    }

}
