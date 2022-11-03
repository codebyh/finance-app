namespace Finance.WebApp.Models.Tax
{
    public class TaxableIncomeInfo
    {
        public TaxFilingStatus TaxFilingStatus { get; set; }

        public int StandardDeduction { get; set; }

        public TaxBracket[] TaxBrackets { get; set; }  
    }
}
