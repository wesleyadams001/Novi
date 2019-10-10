using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Tools
{
    /// <summary>
    /// The base class for Enhanced Enums for .NET
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EnumBaseType<T> where T : EnumBaseType<T>
    {
        protected static List<T> enumValues = new List<T>();

        public readonly int Key;
        public readonly string Value;

        /// <summary>
        /// Base Constructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public EnumBaseType(int key, string value)
        {
            Key = key;
            Value = value;
            enumValues.Add((T)this);
        }

        /// <summary>
        /// Get the readonly collection
        /// </summary>
        /// <returns></returns>
        protected static ReadOnlyCollection<T> GetBaseValues()
        {
            return enumValues.AsReadOnly();
        }

        /// <summary>
        /// Look up by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected static T GetBaseByKey(int key)
        {
            foreach (T t in enumValues)
            {
                if (t.Key == key) return t;
            }
            return null;
        }

        /// <summary>
        /// String Value
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value;
        }
    }
}
