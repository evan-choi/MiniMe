using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json.Linq;
using Serilog;

namespace MiniMe.Core.AspNetCore.Mvc.Formatters
{
    public class FormInputFormatter : TextInputFormatter
    {
        public FormInputFormatter()
        {
            SupportedMediaTypes.Add("application/x-www-form-urlencoded");
            SupportedEncodings.Add(UTF8EncodingWithoutBOM);
            SupportedEncodings.Add(UTF16EncodingLittleEndian);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            try
            {
                using var reader = new StreamReader(context.HttpContext.Request.Body, encoding);
                var value = await reader.ReadToEndAsync();

                IEnumerable<string> lines = Regex.Split(value, "[\r\n]+")
                    .Select(v => v.Trim(' '))
                    .Where(v => !string.IsNullOrEmpty(v));

                JToken result;

                if (context.ModelType.IsArray || typeof(IEnumerable<>).IsAssignableFrom(context.ModelType))
                {
                    var array = new JArray();

                    foreach (var obj in lines.Select(Deserialize))
                    {
                        array.Add(obj);
                    }

                    result = array;
                }
                else
                {
                    result = Deserialize(lines.First());
                }

                return await InputFormatterResult.SuccessAsync(result.ToObject(context.ModelType));
            }
            catch (Exception e)
            {
                Log.Fatal(e, e.Message);
            }

            return await InputFormatterResult.FailureAsync();
        }

        private static JObject Deserialize(string formData)
        {
            var jObj = new JObject();

            foreach (string[] kv in formData.Split('&').Select(kv => kv.Split('=', 2)))
            {
                jObj[kv[0]] = kv[1];
            }

            return jObj;
        }
    }
}
