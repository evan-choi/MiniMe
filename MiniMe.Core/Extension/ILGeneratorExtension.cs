using System;
using System.Reflection;
using System.Reflection.Emit;

namespace MiniMe.Core.Extensions
{
    internal static class ILGeneratorExtension
    {
        public static void EmitBox(this ILGenerator generator, Type type)
        {
            generator.Emit(OpCodes.Box, type);
        }

        public static void EmitUnbox(this ILGenerator generator, Type type)
        {
            if (type.IsValueType)
                generator.Emit(OpCodes.Unbox_Any, type);
            else
                generator.Emit(OpCodes.Castclass, type);
        }

        public static void EmitCall(this ILGenerator generator, MethodInfo methodInfo)
        {
            if (methodInfo.DeclaringType.IsValueType)
                generator.Emit(OpCodes.Call, methodInfo);
            else
                generator.Emit(OpCodes.Callvirt, methodInfo);
        }
    }
}
