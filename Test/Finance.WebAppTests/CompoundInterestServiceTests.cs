namespace Finance.WebAppTests
{
    using Finance.WebApp.Calculations;
    using Finance.WebApp.Models;
    using FluentAssertions;
    using Xunit;


    public class CompoundInterestServiceTests
    {
        [Theory]
        [InlineData(TimeFrequency.Annually, 43_427.37)]
        [InlineData(TimeFrequency.Semiannually, 44_747.27)]
        [InlineData(TimeFrequency.Quaterly, 45_450.35)]
        [InlineData(TimeFrequency.Monthly, 45_936.35)]
        [InlineData(TimeFrequency.Daily, 46_176.54)]
        public void CalculateTest(TimeFrequency timeFrequency, double expectedValue)
        {
            CompoundInterestCalculatorInput input = new CompoundInterestCalculatorInput
            {
                InitialInvestment = 10_000.65,
                MonthlyContribution = 0,
                LengthOfTimeInYears = 18,
                EstimatedInterestRate = 8.5f,
                InterestRateVarianceRange = 0,
                CompoundFrequency = timeFrequency,
            };

            CompoundInterestService.Calculate(input).Should().Be(expectedValue);
        }

        [Fact]
        public void CalculateYearlyTest()
        {
            CompoundInterestCalculatorInput input = new CompoundInterestCalculatorInput
            {
                InitialInvestment = 10_000.65,
                MonthlyContribution = 0,
                LengthOfTimeInYears = 5,
                EstimatedInterestRate = 8.5f,
                InterestRateVarianceRange = 0,
                CompoundFrequency = TimeFrequency.Annually,
            };

            var interestResultList = CompoundInterestService.CalculateYearly(input);
            interestResultList.Count.Should().Be(input.LengthOfTimeInYears);
            interestResultList[0].Should().Be(10_850.71);
            interestResultList[1].Should().Be(11_773.02);
            interestResultList[2].Should().Be(12_773.72);
            interestResultList[3].Should().Be(13_859.49);
            interestResultList[4].Should().Be(15_037.54);

            CompoundInterestService.Calculate(input).Should().Be(interestResultList[4]);
        }
    }
}