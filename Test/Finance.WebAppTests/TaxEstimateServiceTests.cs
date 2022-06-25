namespace Finance.WebAppTests
{
    using Finance.WebApp.Calculations;
    using Finance.WebApp.Models.Tax;
    using Finance.WebApp.Services;
    using FluentAssertions;
    using Xunit;


    public class TaxEstimateServiceTests
    {

        [Fact]
        public void CalculateYearlyTest()
        {
            var taxAmount = new TaxEstimateService().Calculate(2022, TaxFilingStatus.MarriedFilingJointly, 100_000);

            taxAmount.Should().Be(8_480.88);
        }
    }
}