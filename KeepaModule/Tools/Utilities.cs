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

        /// <summary>
        /// Convert Csv to list format
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<string> getListFromCsv(string[,] array)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);
            List<string> ret = new List<string>(width * height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    ret.Add(array[i, j]);
                }
            }
            return ret;
        }


        /// <summary>
        /// Array to a CSV
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string arrayToCsv(string[] array)
        {
            StringBuilder buff = new StringBuilder();
            string sep = "";
            foreach (string s in array)
            {
                buff.Append(sep);
                buff.Append(s);
                sep = ",";
            }
            return buff.ToString();
        }
    }
}
