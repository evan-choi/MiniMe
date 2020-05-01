using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MiniMe.Core.AspNetCore.Mvc
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromBase64FormAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => BindingSource.Custom;
    }
}
