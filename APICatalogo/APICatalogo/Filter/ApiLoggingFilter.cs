using Microsoft.AspNetCore.Mvc.Filters;

namespace APICatalogo.Filter
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //executa antes da action
            _logger.LogInformation("### executando -> OnActionExecuted.");
            _logger.LogInformation("#######################################");
            _logger.LogInformation(DateTime.Now.ToLongTimeString());
            _logger.LogInformation($"Status Code : {context.HttpContext.Response.StatusCode}");
            _logger.LogInformation("#######################################");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //executa antes da action
            _logger.LogInformation("### executando -> OnActionExecuting.");
            _logger.LogInformation("#######################################");
            _logger.LogInformation(DateTime.Now.ToLongTimeString());
            _logger.LogInformation($"modelstate : {context.ModelState.IsValid}");
            _logger.LogInformation("#######################################");
        }
    }
}
