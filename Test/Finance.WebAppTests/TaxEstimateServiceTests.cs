namespace Finance.WebAppTests
{
    using Finance.WebApp.Calculations;
    using Finance.WebApp.Models.Tax;
    using Finance.WebApp.Services;
    using FluentAssertions;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;


    public class TaxEstimateServiceTests
    {

        [Theory]
        [InlineData(2022, 25_900, 0)] // standard deduction
        [InlineData(2022, 25_901, 0.1)] // 10% tax bracket ($0 – $20,550)
        [InlineData(2022, 60_000, 3_681)] // irs = 3,684
        public void CalculateMarriedFilingJointlyTest(int year, double income, double expectedTaxAmount)
        {
            var loggerFactory = new Mock<ILoggerFactory>();
            loggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(new Mock<ILogger>().Object);
            TaxEstimateSummary taxReturnSummary = new TaxEstimateService(loggerFactory.Object).Calculate(year, TaxFilingStatus.MarriedFilingJointly, income);

            taxReturnSummary.TotalTaxAmount.Should().Be(expectedTaxAmount);
        }
    }
}