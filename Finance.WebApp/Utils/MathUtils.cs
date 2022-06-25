namespace Finance.WebApp.Utils
{
    public static class MathUtils
    {
        public static double RoundToTwoDigits(this double amount)
        {
            // round decimal to 2 digits
            return Math.Round(amount, digits: 2);
        }
    }
}
