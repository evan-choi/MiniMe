using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ionic.Zlib;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace MiniMe.Core.AspNetCore.Mvc.ModelBinding.Binders
{
    public class Base64FormModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var bodyReader = new StreamReader(bindingContext.HttpContext.Request.Body);
            var base64 = await bodyReader.ReadToEndAsync();

            if (string.IsNullOrEmpty(base64))
                return;

            var result = await DeserailizeBase64(base64, bindingContext.ModelType);

            bindingContext.Result = ModelBindingResult.Success(result);
        }

        private async Task<object> DeserailizeBase64(string base64, Type modelType)
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
