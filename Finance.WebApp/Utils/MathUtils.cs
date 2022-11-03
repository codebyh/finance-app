namespace Finance.WebApp.Utils
{
    public static class MathUtils
    {
        /// <summary>
        /// Round the decimal value to two digits.
        /// </summary>
        /// <param name="amount">the amount in decimal value</param>
        /// <returns></returns>
        public static double RoundToTwoDigits(this double amount)
        {
            return Math.Round(amount, digits: 2);
        }
    }
}
