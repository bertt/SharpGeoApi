using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SharpGeoApi.Services.FormatFilters
{
    public class CustomFormatFilter : FormatFilter
    {
        const string key = "f";

        public CustomFormatFilter(IOptions<MvcOptions> options, ILoggerFactory loggerFactory) : base(options,loggerFactory)
        {
        }

        public override string GetFormat(ActionContext context)
        {
            var format = context.GetValueFromHeader(key) ?? context.GetValueFromQueryString(key);
            return format;
        }
    }
}
