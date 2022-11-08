namespace Finance.WebAppTests
{
    using Finance.WebApp.Calculations;
    using Finance.WebApp.Models.Tax;
    using Finance.WebApp.Services;
    using FluentAssertions;
    using Xunit;


    public class TaxEstimateServiceTests
    {

        [Theory]
        [InlineData(2022, 25_900, 0)] // standard deduction
        [InlineData(2022, 25_901, 0.1)] // 10% tax bracket ($0 – $20,550)
        [InlineData(2022, 60_000, 3_681)] // irs = 3,684
        public void CalculateMarriedFilingJointlyTest(int year, double income, double expectedTaxAmount)
        {
            TaxEstimateSummary taxReturnSummary = new TaxEstimateService().Calculate(year, TaxFilingStatus.MarriedFilingJointly, income);

            taxReturnSummary.TotalTaxAmount.Should().Be(expectedTaxAmount);
        }
    }
}