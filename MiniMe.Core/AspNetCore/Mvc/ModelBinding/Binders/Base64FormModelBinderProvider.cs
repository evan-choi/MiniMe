using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace MiniMe.Core.AspNetCore.Mvc.ModelBinding.Binders
{
    public class Base64FormModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder _binder = new Base64FormModelBinder();

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata is DefaultModelMetadata defaultModelMetadata &&
                defaultModelMetadata.Attributes.Attributes.Any(a => a is FromBase64FormAttribute))
            {
                return _binder;
            }

            return null;
        }
    }
}
