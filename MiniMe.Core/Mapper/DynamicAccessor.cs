using System;
using System.Reflection;
using System.Reflection.Emit;
using MiniMe.Core.Extensions;

namespace MiniMe.Core.Mapper
{
    internal static class DynamicAccessor
    {
        public delegate object Getter(object obj);
        public delegate void Setter(object obj, object value);
        public delegate object Constructor();

        public static Constructor CreateConstructor(Type type)
        {
            var constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);

            if (type.IsAbstract)
                return null;

            if (constructorInfo == null && !type.IsValueType)
                return null;

            var method = new DynamicMethod(
                ConstructorInfo.ConstructorName,
                typeof(object),
                Type.EmptyTypes,
                typeof(DynamicAccessor).Module,
                true);

            var ilGenerator = method.GetILGenerator();

            if (constructorInfo == null)
            {
                var local = ilGenerator.DeclareLocal(type);
                ilGenerator.Emit(OpCodes.Ldloca_S, local);
                ilGenerator.Emit(OpCodes.Initobj, type);
                ilGenerator.Emit(OpCodes.Ldloc, local);
                ilGenerator.Emit(OpCodes.Box, type);
            }
            else
            {
                ilGenerator.Emit(OpCodes.Newobj, constructorInfo);
            }

            ilGenerator.Emit(OpCodes.Ret);

            return method.CreateDelegate<Constructor>();
        }

        public static Getter CreateMemberGetter(MemberInfo memberInfo)
        {
            if (memberInfo is PropertyInfo propertyInfo)
                return CreatePropertyGetter(propertyInfo);

            if (memberInfo is FieldInfo fieldInfo)
                return CreateFieldGetter(fieldInfo);

            throw new ArgumentException($"MemberInfo '{nameof(memberInfo)}' must be of type FieldInfo or PropertyInfo");
        }

        public static Setter CreateMemberSetter(MemberInfo memberInfo)
        {
            if (memberInfo is PropertyInfo propertyInfo)
                return CreatePropertySetter(propertyInfo);

            if (memberInfo is FieldInfo fieldInfo)
                return CreateFieldSetter(fieldInfo);

            throw new ArgumentException($"MemberInfo '{nameof(memberInfo)}' must be of type FieldInfo or PropertyInfo");
        }

        public static Getter CreateFieldGetter(FieldInfo fieldInfo)
        {
            if (!fieldInfo.IsPublic)
                return null;

            var method = CreateGetterMethod(fieldInfo.Name);
            var ilGenerator = method.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.EmitUnbox(fieldInfo.DeclaringType);
            ilGenerator.Emit(OpCodes.Ldfld, fieldInfo);
            ilGenerator.EmitBox(fieldInfo.FieldType);
            ilGenerator.Emit(OpCodes.Ret);

            return method.CreateDelegate<Getter>();
        }

        public static Setter CreateFieldSetter(FieldInfo fieldInfo)
        {
            if (!fieldInfo.IsPublic)
                return null;

            var method = CreateSetterMethod(fieldInfo.Name);
            var ilGenerator = method.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.EmitUnbox(fieldInfo.DeclaringType);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.EmitUnbox(fieldInfo.FieldType);
            ilGenerator.Emit(OpCodes.Stfld, fieldInfo);
            ilGenerator.Emit(OpCodes.Ret);

            return method.CreateDelegate<Setter>();
        }

        public static Getter CreatePropertyGetter(PropertyInfo propertyInfo)
        {
            if (propertyInfo.GetMethod?.IsPublic != true)
                return null;

            var method = CreateGetterMethod(propertyInfo.GetMethod.Name);
            var ilGenerator = method.GetILGenerator();
            
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.EmitUnbox(propertyInfo.DeclaringType);
            ilGenerator.EmitCall(propertyInfo.GetMethod);
            ilGenerator.EmitBox(propertyInfo.PropertyType);
            ilGenerator.Emit(OpCodes.Ret);

            return method.CreateDelegate<Getter>();
        }

        public static Setter CreatePropertySetter(PropertyInfo propertyInfo)
        {
            if (propertyInfo.SetMethod?.IsPublic != true)
                return null;

            var method = CreateSetterMethod(propertyInfo.SetMethod.Name);
            var ilGenerator = method.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.EmitUnbox(propertyInfo.DeclaringType);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.EmitUnbox(propertyInfo.PropertyType);
            ilGenerator.EmitCall(propertyInfo.SetMethod);
            ilGenerator.Emit(OpCodes.Ret);

            return method.CreateDelegate<Setter>();
        }

        private static DynamicMethod CreateGetterMethod(string name)
        {
            return new DynamicMethod(
                name, 
                typeof(object),
                new[] { typeof(object) }, 
                typeof(DynamicAccessor).Module,
                true);
        }

        private static DynamicMethod CreateSetterMethod(string name)
        {
            return new DynamicMethod(
                name,
                typeof(void),
                new[] { typeof(object), typeof(object) },
                typeof(DynamicAccessor).Module,
                true);
        }
    }
}
