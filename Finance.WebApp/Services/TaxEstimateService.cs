namespace Finance.WebApp.Services
{
    using Finance.WebApp.Models.Tax;
    using Finance.WebApp.Utils;

    public class TaxEstimateService
    {
        public double Calculate(int year, TaxFilingStatus filingStatus, double income)
        {
            int defaultYear = TaxConstants.TaxYear2022;
            switch (filingStatus)
            {
                case TaxFilingStatus.MarriedFilingJointly:
                    return CaclulateTaxAmount(year: 2022, filingStatus, income);
                default:
                    throw new NotImplementedException("Tax Filing Status not supported");
            }
        }

        double CaclulateTaxAmount(int year, TaxFilingStatus filingStatus, double income)
        {
            TaxableIncomeInfo taxableIncomeInfo = GetTaxYear(year).GetTaxInfoByFilingStaus(filingStatus);

            // Perform Adjestments
            income = income - taxableIncomeInfo.StandardDeduction;

            double accumulatedTaxAmount = 0;
            foreach (var taxBracket in taxableIncomeInfo.TaxBrackets)
            {
                if (income > taxBracket.TaxableIncomeMin)
                {
                    double taxableIncomeInBracket = Math.Min(
                        income - taxBracket.TaxableIncomeMin,
                        taxBracket.TaxableIncomeMax - taxBracket.TaxableIncomeMin);

                    accumulatedTaxAmount += taxableIncomeInBracket * taxBracket.TaxRate;
                }
                else
                {
                    break;
                }
            }

            return accumulatedTaxAmount.RoundToTwoDigits();
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
