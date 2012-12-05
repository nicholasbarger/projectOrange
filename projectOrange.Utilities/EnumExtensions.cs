using System;
using System.ComponentModel;
using System.Reflection;

namespace projectOrange.Utilities
{
    /// <summary>
    /// A collection of extension methods for enums.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Enum<T>
    {
        /// <summary>
        /// An extension method for enums to get the textual description of a specified enum value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(T value)  
        { 
            var da = (DescriptionAttribute[])(typeof(T).GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false));  
            return da.Length > 0 ? da[0].Description : value.ToString();  
        }

        /// <summary>
        /// An extension method for enums to get the enum by textual description.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string GetEnumName(Type value, string description)
        {
            FieldInfo[] fis = value.GetFields();
            foreach (FieldInfo fi in fis)
            {
                DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes
                  (typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    if (attributes[0].Description == description)
                    {
                        return fi.Name;
                    }
                }
            }
            return description;
        }
    }
}