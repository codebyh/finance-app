namespace Finance.WebApp.Models.Tax
{
    public interface TaxYear
    {
        public TaxableIncomeInfo GetTaxInfoByFilingStaus(TaxFilingStatus taxFilingStatus);
    }

}
