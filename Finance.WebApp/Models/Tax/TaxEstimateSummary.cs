namespace Finance.WebApp.Models.Tax
{
    public class TaxEstimateSummary
    {
        public double Income { get; set; }
        public double StandardDeduction { get; set; }
        // Other deductions: 401k/IRA, HSA/FSA, Penalty for Early Withdrawal of Savings
        // Itemized deductions: medical & dental expense, taxes paid, Qualified mortgage interest and investment interest expenses, casulaty losses
        // Min(StandardDeduction, ItemizedDeduction)
        //public double TotalDeductions { get; set; }
        public double TaxableIncome { get; set; }
        public List<TaxBracket> TaxBrackets { get; set; }
        public double TotalTaxAmount { get; set; }
    }

    /// <summary>
    /// Tax credits are amounts you subtract directly from your tax obligation.
    /// </summary>
    public class TaxCredits
    {
        //Child and Dependent Credits

    }

}
