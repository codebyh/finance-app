namespace Finance.WebApp.Calculations
{
    using Finance.WebApp.Models;
    using Finance.WebApp.Utils;

    public static class CompoundInterestCalculator
    {
        public static double Calculate(CompoundInterestCalculatorInput input)
        {
            return CompoundInterest(input.InitialInvestment, input.EstimatedInterestRate, input.CompoundFrequency.GetFrequencyValue(), input.LengthOfTimeInYears);
        }

        public static IList<double> CalculateYearly(CompoundInterestCalculatorInput input)
        {
            IList<double> interestList = new List<double>();

            double compoundAmount = input.InitialInvestment;
            for (int i = 0; i < input.LengthOfTimeInYears; i++)
            {
                compoundAmount = CompoundInterest(compoundAmount, input.EstimatedInterestRate, input.CompoundFrequency.GetFrequencyValue(), 1);
                interestList.Add(compoundAmount);
            }

            return interestList;
        }

        public static double CompoundInterest(
            double initialAmount,
            float interestRate,
            int compoundInterval,
            int timeInYears) // TODO: Withdrawal, Deposit, with inflation
        {
            double compoundInterest = initialAmount * Math.Pow(1 + (interestRate * 0.01) / compoundInterval, timeInYears);

            // round decimal to 2 digits
            var compoundInterestRounded = Math.Round(compoundInterest, digits: 2);

            return compoundInterestRounded;
        }
    }
}
