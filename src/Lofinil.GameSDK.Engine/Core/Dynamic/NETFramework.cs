using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Lofinil.GameSDK.Engine
{
    public class NETFramework
    {
        public static Object GetPropertyByName(Object obj, String name)
        {
            // 调用派生类的GetParamMap静态方法
            // 从公共字段中寻找
            FieldInfo fi = null;
            fi = obj.GetType().GetField(name);
            if (fi != null)
            {
                Object objValue = fi.GetValue(obj);
                return objValue == null ? null : objValue.ToString();
            }

            // 从公共属性中寻找
            PropertyInfo pi = null;
            pi = obj.GetType().GetProperty(name);
            if (pi != null)
            {
                Object objValue = pi.GetValue(obj, null);
                return objValue == null ? null : objValue.ToString();
            }

            Console.WriteLine("未找到字段或属性：{0}", name);
            return null;
        }

        public static void SetPropertyByName(Object obj, String name, Object value)
        {
            // 从公共字段中寻找
            FieldInfo fi = null;
            fi = obj.GetType().GetField(name);
            if (fi != null)
            {
                fi.SetValue(obj, value);
                return;
            }

            // 从公共属性中寻找
            PropertyInfo pi = null;
            pi = obj.GetType().GetProperty(name);
            if (pi != null)
            {
                pi.SetValue(obj, value, null);
                return;
            }

            Console.WriteLine("未找到字段或属性：{0}", name);
        }

        public static void ActionCall(Object obj, String name, Object[] param)
        {
            MethodInfo methodInfo = obj.GetType().GetMethod(name);
            methodInfo.Invoke(obj, param);
        }

        public static Object FuncCall(Object obj, String name, Object[] param)
        {
            MethodInfo methodInfo = obj.GetType().GetMethod(name);
            return methodInfo.Invoke(obj, param);
        }

        public static bool IsModule(Type t)
        {
            object[] attrs = t.GetCustomAttributes(typeof(ModuleAttribute), false);
            if (attrs.Count() == 0)
                return false;
            else
                return true;
        }

        public static bool IsComponent(Type t, bool offHide)
        {
            object[] attrs = t.GetCustomAttributes(typeof(ComponentAttribute), false);
            if (attrs.Count() == 0)
                return false;
            else
            {
                return true;
            }
        }

        public static ComponentAttribute GetCompAttr(Type t)
        {
            object[] attrs = t.GetCustomAttributes(typeof(ComponentAttribute), false);
            if (attrs.Count() == 0)
                return null;
            else
                return (ComponentAttribute)attrs[0];
        }

        public static Type[] GetCompParentTypes(Type compType)
        {
            object[] attrs = compType.GetCustomAttributes(typeof(ComponentAttribute), false);
            if (attrs.Count() == 0)
                return new Type[0];

            ComponentAttribute compAttr = (ComponentAttribute)attrs[0];
            return compAttr.DepParents;
        }

        public static Type[] GetModuleDepTypes(Type modType)
        {
            object[] attrs = modType.GetCustomAttributes(typeof(ModuleAttribute), false);
            if (attrs.Count() == 0)
                return new Type[0];

            ModuleAttribute modAttr = (ModuleAttribute)attrs[0];
            return modAttr.Depends;
        }

        public static bool IsPrefab(Type t)
        {
            object[] attrs = t.GetCustomAttributes(typeof(PrefabAttribute), false);
            return attrs.Count() != 0;
        }

        public static bool IsAction(MethodInfo info)
        {
            if (info.ReturnType == typeof(void) &&
                IsInteract(info))
                return true;
            return false;
        }

        public static bool IsAccessor(MethodInfo info)
        {
            if (info.ReturnType != typeof(void) &&
                info.ReturnType != typeof(bool) &&
                IsInteract(info))
                return true;
            return false;
        }

        public static bool IsChecker(MethodInfo info)
        {
            if (info.ReturnType == typeof(bool) &&
                IsInteract(info))
                return true;
            return false;
        }

        public static bool IsInteract(MethodInfo info)
        {
            object[] attrs = info.GetCustomAttributes(typeof(InteractAttribute), false);
            return attrs.Count() != 0;
        }

        public static InteractAttribute GetInteractAttribute(MethodInfo info)
        {
            object[] attrs = info.GetCustomAttributes(typeof(InteractAttribute), false);
            if (attrs.Count() != 0)
            {
                return attrs[0] as InteractAttribute;
            }
            return null;
        }

        public static Type[] GetAllChildren(Assembly asm, Type p)
        {
            List<Type> list = new List<Type>();
            Type[] allTypes = asm.GetTypes();
            foreach (Type t in allTypes)
            {
                if (t.IsSubclassOf(p))
                    list.Add(t);
            }
            return list.ToArray();
        }

    }
}
