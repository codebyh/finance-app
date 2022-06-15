namespace Finance.WebApp.Calculations
{
    using Finance.WebApp.Models;
    using Finance.WebApp.Utils;

    public class CompoundInterestCalculator
    {
        public double Calculate(CompoundInterestCalculatorInput input)
        {
            double compoundInterest = input.InitialInvestment * Math.Pow(1 + (input.EstimatedInterestRate * 0.01)/input.CompoundFrequency.GetFrequencyValue(), input.LengthOfTimeInYears);

            return compoundInterest;
        }
    }
}
