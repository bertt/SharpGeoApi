using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SharpGeoApi.Services.Formatters
{
    public class HtmlMediaTypeFormatter : TextOutputFormatter
    {
        IConfiguration configuration;

        public HtmlMediaTypeFormatter(IConfiguration configuration)
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/html"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            this.configuration = configuration;
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var sb = new StringBuilder();

            var serviceProvider = context.HttpContext.RequestServices;
            var viewengine = (IRazorViewEngine)serviceProvider.GetService(typeof(IRazorViewEngine));

            var obj = context.Object;
            // todo: write obj to html representation
            // todo :use razor to render?
            sb.Append("uyoyoy");
            return context.HttpContext.Response.WriteAsync(sb.ToString());
        }
    }
}