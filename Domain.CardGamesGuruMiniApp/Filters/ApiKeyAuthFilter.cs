using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Domain.CardGamesGuruMiniApp.Filters
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private const string ApiKeySectionName = "Authentication:ApiKey";
        private const string ApiKeyHeaderName = "X-Api-Key";

        private readonly IConfiguration _configuration;

        public ApiKeyAuthFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("API Key missing");
                return;
            }

            var apiKey = _configuration.GetValue<string>(ApiKeySectionName);
            if (!apiKey.Equals(extractedApiKey) || string.IsNullOrEmpty(apiKey))
            {
                context.Result = new UnauthorizedObjectResult("API Key is invalid");
                return;
            }

        }
    }
}