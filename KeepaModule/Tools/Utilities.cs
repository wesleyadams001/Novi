using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepaModule.Tools
{
    /// <summary>
    /// A Generic Utilities class
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Transforms a string dictionary into a keepa URL format string
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static string getQueryString(IDictionary<string, string> dict)
        {
            var list = new List<string>();
            foreach (var item in dict)
            {
                list.Add(item.Key + "=" + item.Value);
            }
            return string.Join("&", list);
        }
    }
}
