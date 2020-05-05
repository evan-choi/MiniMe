using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;

namespace MiniMe.Core.AspNetCore.Mvc.Formatters
{
    public class FormOutputFormatter : TextOutputFormatter
    {
        private readonly bool _ignoreContentType;

        public FormOutputFormatter(bool ignoreContentType = false)
        {
            _ignoreContentType = ignoreContentType;
            
            SupportedMediaTypes.Add(MediaTypeNames.Text.Plain);
            SupportedMediaTypes.Add("application/x-www-form-urlencoded");
            SupportedEncodings.Add(Encoding.UTF8);
        }

        protected override bool CanWriteType(Type type)
        {
            return !type.IsValueType;
        }

        public override bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            return _ignoreContentType || context.HttpContext.Request.ContentType == "application/x-www-form-urlencoded";
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

            string result;

            if (context.Object is IEnumerable<object> enumerable)
            {
                result = string.Join(Environment.NewLine, enumerable.Select(Serialize));
            }
            else
            {
                result = Serialize(context.Object);
            }

            result += Environment.NewLine;

            await context.HttpContext.Response.WriteAsync(result, selectedEncoding);
        }

        private static string Serialize(object obj)
        {
            IEnumerable<string> propertyParams = JObject.FromObject(obj)
                .Children()
                .OfType<JProperty>()
                .Select(p => $"{p.Name}={p.Value}");

            return string.Join("&", propertyParams);
        }
    }
}
