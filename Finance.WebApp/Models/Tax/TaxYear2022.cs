namespace Finance.WebApp.Models.Tax
{
    public class TaxYear2022 : TaxYear
    {
        const int MarriedFilingJointlyStandardDeduction = 25_900;
        const int SingleStandardDeduction = 12_950;
        const int MarriedFilingSeparatelyStandardDeduction = 12_950;
        const int HeadOfHouseholdStandardDeduction = 19_400;

        public TaxableIncomeInfo GetTaxInfoByFilingStaus(TaxFilingStatus taxFilingStatus)
        {
            switch (taxFilingStatus)
            {
                case TaxFilingStatus.MarriedFilingJointly:
                    return new TaxableIncomeInfo
                    {
                        StandardDeduction = MarriedFilingJointlyStandardDeduction,
                        TaxFilingStatus = TaxFilingStatus.MarriedFilingJointly,
                        TaxBrackets = MarriedFilingJointlyTaxBrackets(),
                    };
                default:
                    throw new NotImplementedException("Tax Filing Status not supported");
            }
        }

        TaxBracket[] MarriedFilingJointlyTaxBrackets()
        {
            return new TaxBracket[] {
                new TaxBracket { TaxableIncomeMin =       0, TaxableIncomeMax =  20_550,         TaxRate = 0.10 },
                new TaxBracket { TaxableIncomeMin =  20_551, TaxableIncomeMax =  83_550,         TaxRate = 0.12 },
                new TaxBracket { TaxableIncomeMin =  83_551, TaxableIncomeMax = 178_150,         TaxRate = 0.22 },
                new TaxBracket { TaxableIncomeMin = 178_151, TaxableIncomeMax = 340_100,         TaxRate = 0.24 },
                new TaxBracket { TaxableIncomeMin = 340_101, TaxableIncomeMax = 431_900,         TaxRate = 0.32 },
                new TaxBracket { TaxableIncomeMin = 431_901, TaxableIncomeMax = 647_850,         TaxRate = 0.35 },
                new TaxBracket { TaxableIncomeMin = 647_851, TaxableIncomeMax = double.MaxValue, TaxRate = 0.37 },
            };
        }

    }
}
