using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace MiniMe.Core.AspNetCore.Mvc.Formatters
{
    public class FormOutputFormatter : TextOutputFormatter
    {
        public FormOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/plain"));

            // Shift-JIS
            SupportedEncodings.Add(Encoding.GetEncoding(932));
        }

        public override bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            return context.HttpContext.Request.ContentType == "application/x-www-form-urlencoded";
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (selectedEncoding == null)
            {
                throw new ArgumentNullException(nameof(selectedEncoding));
            }

            IEnumerable<string> propertyParams = JObject.FromObject(context.Object)
                .Children()
                .OfType<JProperty>()
                .Select(p => $"{p.Name}={p.Value}");

            string result = string.Join("&", propertyParams) + '\n';

            await context.HttpContext.Response.WriteAsync(result, selectedEncoding);
        }
    }
}
