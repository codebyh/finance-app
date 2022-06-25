namespace Finance.WebApp.Calculations
{
    using Finance.WebApp.Models;
    using Finance.WebApp.Utils;

    public static class CompoundInterestService
    {
        public static double Calculate(CompoundInterestCalculatorInput input)
        {
            return CompoundInterest(
                input.InitialInvestment,
                input.EstimatedInterestRate,
                input.CompoundFrequency.GetFrequencyValue(),
                input.LengthOfTimeInYears)
                .RoundToTwoDigits();
        }

        public static IList<double> CalculateYearly(CompoundInterestCalculatorInput input)
        {
            IList<double> interestList = new List<double>();

            double compoundAmount = input.InitialInvestment;
            for (int i = 0; i < input.LengthOfTimeInYears; i++)
            {
                compoundAmount = CompoundInterest(compoundAmount, input.EstimatedInterestRate, input.CompoundFrequency.GetFrequencyValue(), 1);
                interestList.Add(compoundAmount.RoundToTwoDigits());
            }

            return interestList;
        }

        public static double CompoundInterest(
            double initialAmount,
            float interestRate,
            int compoundInterval,
            int timeInYears) // TODO: Withdrawal, Deposit, with inflation
        {
            double compoundInterest = initialAmount * Math.Pow(1 + (interestRate * 0.01) / compoundInterval, compoundInterval * timeInYears);

            return compoundInterest;
        }

        static double RoundToTwoDigits(this double amount)
        {
            // round decimal to 2 digits
            return Math.Round(amount, digits: 2);
        }
    }
}
