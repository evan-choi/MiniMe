using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zlib;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json.Linq;

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
            using var reader = new StreamReader(context.HttpContext.Request.Body);
            var base64 = await reader.ReadToEndAsync();

            if (string.IsNullOrEmpty(base64))
                return await InputFormatterResult.FailureAsync();

            var result = await DeserailizeBase64Async(base64, context.ModelType);

            return await InputFormatterResult.SuccessAsync(result);
        }

        private async Task<object> DeserailizeBase64Async(string base64, Type modelType)
        {
            await using var buffer = new MemoryStream(Convert.FromBase64String(base64));
            await using var zlibStream = new ZlibStream(buffer, CompressionMode.Decompress);
            using var reader = new StreamReader(zlibStream);
            var value = await reader.ReadToEndAsync();

            value = value.TrimEnd('\r', '\n');

            var jObj = new JObject();

            foreach (string[] kv in value.Split('&').Select(kv => kv.Split('=', 2)))
            {
                jObj[kv[0]] = kv[1];
            }

            return jObj.ToObject(modelType);
        }
    }
}
