using System;
using System.Reflection;
using System.Reflection.Emit;
using MiniMe.Core.Utilities;

namespace MiniMe.Core.Extensions
{
    internal static class ReflectionExtension
    {
        public static TDelegate CreateDelegate<TDelegate>(this DynamicMethod method) where TDelegate : Delegate
        {
            return (TDelegate)method.CreateDelegate(typeof(TDelegate));
        }

        public static FieldInfo GetBackingField(this PropertyInfo propertyInfo)
        {
            var fieldName = $"<{propertyInfo.Name}>k__BackingField";
            return propertyInfo.DeclaringType!.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static object GetMemberValue(this MemberInfo memberInfo, object target)
        {
            Validation.ArgumentNotNull(memberInfo, nameof(memberInfo));
            Validation.ArgumentNotNull(target, nameof(target));

            switch (memberInfo)
            {
                case PropertyInfo propertyInfo:
                    return propertyInfo.GetValue(target);

                case FieldInfo fieldInfo:
                    return fieldInfo.GetValue(target);

                default:
                    throw new ArgumentException($"MemberInfo '{nameof(memberInfo)}' must be of type FieldInfo or PropertyInfo");
            }
        }

        public static void SetMemberValue(this MemberInfo memberInfo, object target, object value)
        {
            Validation.ArgumentNotNull(memberInfo, nameof(memberInfo));
            Validation.ArgumentNotNull(target, nameof(target));

            switch (memberInfo)
            {
                case PropertyInfo propertyInfo:
                    propertyInfo.SetValue(target, value);
                    break;

                case FieldInfo fieldInfo:
                    fieldInfo.SetValue(target, value);
                    break;

                default:
                    throw new ArgumentException($"MemberInfo '{nameof(memberInfo)}' must be of type FieldInfo or PropertyInfo");
            }
        }
    }
}
