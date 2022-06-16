namespace Finance.WebAppTests
{
    using Finance.WebApp.Calculations;
    using Finance.WebApp.Models;
    using FluentAssertions;
    using Xunit;


    public class CompoundInterestCalculatorTest
    {
        [Fact]
        public void Test()
        {
            CompoundInterestCalculatorInput input = new CompoundInterestCalculatorInput
            {
                InitialInvestment = 10_000,
                MonthlyContribution = 0,
                LengthOfTimeInYears = 18,
                EstimatedInterestRate = 8.0f,
                InterestRateVarianceRange = 0,
                CompoundFrequency = TimeFrequency.Annually
            };

            CompoundInterestCalculator.Calculate(input).Should().Be(39960.19);

            var interestResultList = CompoundInterestCalculator.CalculateYearly(input);
            interestResultList.Count.Should().Be(input.LengthOfTimeInYears);
            interestResultList[input.LengthOfTimeInYears - 1].Should().Be(39960.17);
        }
    }
}