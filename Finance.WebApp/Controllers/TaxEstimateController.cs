namespace Finance.WebApp.Controllers
{
    using Finance.WebApp.Common;
    using Finance.WebApp.Models;
    using Finance.WebApp.Models.Tax;
    using Finance.WebApp.Services;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [ApiController]
    [Route("[controller]")]
    public class TaxEstimateController : ControllerBase
    {
        //private readonly ILogger<WeatherForecastController> logger;
        //public TaxEstimateController(ILogger<WeatherForecastController> logger)
        //{
        //    this.logger = logger;
        //}

        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger logger;
        public TaxEstimateController(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory.CreateLogger(nameof(TaxEstimateController));
        }

        [HttpPost(Name = "TaxEstimate")]
        public TaxEstimateSummary Post([FromBody] TaxEstimateInput taxInput)
        {
            this.logger.LogInformation(LogEvents.GetTaxItems, $"{DateTimeOffset.UtcNow} Input received: {JsonConvert.SerializeObject(taxInput)}");
            return new TaxEstimateService(this.loggerFactory).Calculate(2022, taxInput.FilingStatus, taxInput.Income);
        }
    }
}