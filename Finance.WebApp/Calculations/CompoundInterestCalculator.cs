using Finance.WebApp.Models;

namespace Finance.WebApp.Calculations
{
    public class CompoundInterestCalculator
    {
        public double Calculate(CompoundInterestCalculatorInput input)
        {
            double compoundInterest = input.InitialInvestment * Math.Pow(1 + input.EstimatedInterestRate / 100, input.LengthOfTimeInYears);

            return compoundInterest;
        }
    }
}
