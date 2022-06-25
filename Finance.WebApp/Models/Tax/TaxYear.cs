namespace Finance.WebApp.Models.Tax
{
    public abstract class TaxYear
    {
        public abstract TaxBracket[] GetMarriedFilingJointlyTaxBrackets();
        public abstract double GetStandardDeduction();
    }

}
