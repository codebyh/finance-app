namespace Finance.WebApp.Models.Tax
{
    public class TaxBracket
    {
        public double TaxableIncomeMin { get; set; }
        public double TaxableIncomeMax { get; set; }
        public double TaxRate { get; set; }
    }
}
