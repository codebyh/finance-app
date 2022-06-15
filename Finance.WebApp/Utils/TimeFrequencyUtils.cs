namespace Finance.WebApp.Utils
{
    using Finance.WebApp.Models;

    public static class TimeFrequencyUtils
    {
        public static int GetFrequencyValue(this TimeFrequency frequency)
        {
            switch (frequency)
            {
                case TimeFrequency.Annually:
                    return 1;
                case TimeFrequency.Semiannually:
                    return 2;
                case TimeFrequency.Quaterly:
                    return 4;
                case TimeFrequency.Monthly:
                    return 12;
                case TimeFrequency.Daily:
                    return 365;
                default:
                    return 1;

            }
        }
    }
}
