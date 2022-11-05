namespace Finance.WebApp.Controllers
{
    using Finance.WebApp.Models;
    using Finance.WebApp.Models.Tax;
    using Finance.WebApp.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class TaxEstimateController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public TaxEstimateController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "TaxEstimate")]
        public TaxEstimateSummary Post([FromBody] TaxEstimateInput payload)
        {
            return new TaxEstimateService().Calculate(2022, payload.FilingStatus, payload.Income);
        }
    }
}