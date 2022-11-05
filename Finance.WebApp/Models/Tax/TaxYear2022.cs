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
                new TaxBracket { LowerBracketAmount =       0, UpperBracketAmount =  20_550,         TaxRate = 0.10 },
                new TaxBracket { LowerBracketAmount =  20_550, UpperBracketAmount =  83_550,         TaxRate = 0.12 },
                new TaxBracket { LowerBracketAmount =  83_550, UpperBracketAmount = 178_150,         TaxRate = 0.22 },
                new TaxBracket { LowerBracketAmount = 178_150, UpperBracketAmount = 340_100,         TaxRate = 0.24 },
                new TaxBracket { LowerBracketAmount = 340_100, UpperBracketAmount = 431_900,         TaxRate = 0.32 },
                new TaxBracket { LowerBracketAmount = 431_900, UpperBracketAmount = 647_850,         TaxRate = 0.35 },
                new TaxBracket { LowerBracketAmount = 647_850, UpperBracketAmount = double.MaxValue, TaxRate = 0.37 },
            };
        }

    }
}
