namespace Finance.WebApp.Models
{
    public class CompoundInterestCalculatorInput
    {
        public double InitialInvestment { get; set; }
        public double MonthlyContribution { get; set; }
        public int LengthOfTimeInYears { get; set; }
        public float EstimatedInterestRate { get; set; }
        public float InterestRateVarianceRange { get; set; }
        public TimeFrequency CompoundFrequency { get; set; }
    }
}
