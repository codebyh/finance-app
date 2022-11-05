namespace Finance.WebApp.Models.Tax
{
    public class TaxBracket
    {
        public double LowerBracketAmount { get; set; }
        public double UpperBracketAmount { get; set; }
        public double TaxRate { get; set; }
        public double TaxAmount { get; set; }
    }
}
