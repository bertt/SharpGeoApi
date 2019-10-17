using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace SharpGeoApi.Services
{
    public static class HttpRequestExtensions
    {
        public static string GetValueFromQueryString(this ActionContext context, string key)
        {
            StringValues queryValue;
            if (context.HttpContext.Request.Query.TryGetValue(key, out queryValue))
            {
                return queryValue.ToString();
            }

            return null;
        }

        public static string GetValueFromHeader(this ActionContext context, string key)
        {
            StringValues headerValue;
            if (context.HttpContext.Request.Headers.TryGetValue(key, out headerValue))
            {
                return headerValue.ToString();
            }

            return null;
        }
    }
}
