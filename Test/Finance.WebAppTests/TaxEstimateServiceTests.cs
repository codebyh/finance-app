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
        [InlineData(2022, 58_235, 0)] 
        [InlineData(2022, 46_450, 0)]
        // [InlineData(2022, 83_550, 0)] // 
        public void CalculateMarriedFilingJointlyTest(int year, double income, double expectedTaxAmount)
        {
            var taxAmount = new TaxEstimateService().Calculate(year, TaxFilingStatus.MarriedFilingJointly, income);

            taxAmount.Should().Be(expectedTaxAmount);
        }
    }
}