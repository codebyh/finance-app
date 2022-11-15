namespace Finance.WebApp.Services
{
    using Finance.WebApp.Common;
    using Finance.WebApp.Models.Tax;
    using Finance.WebApp.Utils;
    using Newtonsoft.Json;

    public class TaxEstimateService
    {
        private readonly ILogger logger;

        public TaxEstimateService(ILoggerFactory logger)
        {
            this.logger = logger.CreateLogger(nameof(TaxEstimateService));
        }

        public TaxEstimateSummary Calculate(int year, TaxFilingStatus filingStatus, double income)
        {
            int defaultYear = TaxConstants.TaxYear2022;
            switch (filingStatus)
            {
                case TaxFilingStatus.MarriedFilingJointly:
                    return CaclulateTax(year: 2022, filingStatus, income);
                default:
                    throw new NotImplementedException("Tax Filing Status not supported");
            }
        }

        TaxEstimateSummary CaclulateTax(int year, TaxFilingStatus filingStatus, double income)
        {
            this.logger.LogInformation(LogEvents.GetTaxItems, $"Tax year: {year}, tax filing status: {filingStatus}, income: {income}");
            TaxableIncomeInfo taxableIncomeInfo = GetTaxYear(year).GetTaxInfoByFilingStaus(filingStatus);

            TaxEstimateSummary taxReturnSummary = new TaxEstimateSummary();
            taxReturnSummary.Income = income;
            taxReturnSummary.StandardDeduction = taxableIncomeInfo.StandardDeduction;

            // Perform Adjustments
            double taxableIncome = income - taxableIncomeInfo.StandardDeduction;
            taxReturnSummary.TaxableIncome = taxableIncome;
            taxReturnSummary.TaxBrackets = new List<TaxBracket>();

            double totalTaxAmount = 0;
            foreach (var taxBracket in taxableIncomeInfo.TaxBrackets)
            {
                if (taxableIncome >= taxBracket.LowerBracketAmount)
                {
                    double taxableIncomeInBracket = Math.Min(
                        taxableIncome - taxBracket.LowerBracketAmount,
                        taxBracket.UpperBracketAmount - taxBracket.LowerBracketAmount);

                    double taxAmountInBracket = taxableIncomeInBracket * taxBracket.TaxRate;
                    totalTaxAmount += taxAmountInBracket;

                    taxReturnSummary.TaxBrackets.Add(new TaxBracket
                    {
                        LowerBracketAmount = taxBracket.LowerBracketAmount,
                        UpperBracketAmount = taxBracket.UpperBracketAmount - taxBracket.LowerBracketAmount,
                        TaxRate = taxBracket.TaxRate,
                        TaxAmount = taxAmountInBracket,
                    });
                }
                else
                {
                    break;
                }
            }

            taxReturnSummary.TotalTaxAmount = totalTaxAmount;
            this.logger.LogInformation(LogEvents.GetTaxItems, $"Tax return summary: {JsonConvert.SerializeObject(taxReturnSummary)}");
            return taxReturnSummary;
        }

        TaxYear GetTaxYear(int year)
        {
            switch (year)
            {
                case 2022:
                    return new TaxYear2022();
                default:
                    throw new NotImplementedException("Tax Year not supported");
            }
        }

    }
}
