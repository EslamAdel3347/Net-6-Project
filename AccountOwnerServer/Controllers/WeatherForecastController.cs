using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositorywrapper _wrapper;
        public WeatherForecastController(ILoggerManager logger, IRepositorywrapper wrapper)
        {
            _logger = logger;
            _wrapper = wrapper;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is info message from the controller.");
            _logger.LogDebug("Here is debug message from the controller.");
            _logger.LogWarn("Here is warn message from the controller.");
            _logger.LogError("Here is error message from the controller.");


            var domesticAccounts = _wrapper.Account.FindByCondition(x => x.AccountType.Equals("Domestic"));
            var owners = _wrapper.Owner.FindAll();
            return new string[] { "value1", "value2" };
        }
    }
}