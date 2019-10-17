using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SharpGeoApi.Services.Formatters
{
    public class HtmlMediaTypeFormatter : TextOutputFormatter
    {
        public HtmlMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/html"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);

        }
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var sb = new StringBuilder();

            var obj = context.Object;
            // todo: write obj to html representation
            sb.Append("uyoyoy");
            return context.HttpContext.Response.WriteAsync(sb.ToString());
        }
    }
}