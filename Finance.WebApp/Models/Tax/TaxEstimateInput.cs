namespace Finance.WebApp.Models.Tax
{
    using Newtonsoft.Json;
    using System.ComponentModel;

    public class TaxEstimateInput
    {
        public double Income { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(TaxFilingStatus.MarriedFilingJointly)]
        public TaxFilingStatus FilingStatus { get; set; }

    }
}
