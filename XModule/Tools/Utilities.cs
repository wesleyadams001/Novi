﻿using Newtonsoft.Json;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Tools
{
    /// <summary>
    /// A Utilities library for the Keepa.Core
    /// </summary>
    public static class Utilities
    {

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

        /// <summary>
        /// Get current time (Seconds)
        /// </summary>
        /// <returns></returns>
        public static long getUnixTime()
        {
            Instant accNow = SystemClock.Instance.GetCurrentInstant();
            var now = accNow.ToUnixTimeSeconds();
            return now;
        }

        /// <summary>
        /// Get current time (Milliseconds)
        /// </summary>
        /// <returns></returns>
        public static long getUnixTime(int x)
        {
            Instant accNow = SystemClock.Instance.GetCurrentInstant();
            var now = accNow.ToUnixTimeMilliseconds();
            return now;
        }

        /// <summary>
        /// Convert keepa time to unit time
        /// </summary>
        /// <param name="keepaTime"></param>
        /// <returns></returns>
        public static long getUnixTimeFromKeepaTime(int keepaTime)
        {
            var newkeepa = (long)keepaTime;
            long unixTime = (newkeepa + 21564000) * 60;
            return unixTime;
        }

        /// <summary>
        /// Gets a string version of a jagged array that can be inserted 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string getStringOfArray(int[][] array)
        {
            //check for null condition
            if (array != null)
            {
                //call function to convert to dimensional array
                var dimensionalArray = ConvertToDimensionalArray(array);

                //serialize
                var str = $@"{{{{{JsonConvert.SerializeObject(dimensionalArray).Trim('[', ']').Replace("[", "{").Replace("]", "}")}}}}}";

                //str = str.Replace(",null", ",{null, null}");
                return str;
            }
            else
            {
                return "null";
            }

        }

        /// <summary>
        /// Convert to dimensional array
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static int?[,] ConvertToDimensionalArray(int[][] arr)
        {
            //get longest sub array in jagged array
            //set initial length to first value
            var val = 2;

            //cycle through each item in jagged array
            for (int x = 0; x < arr.Length; x++)
            {
                //if item at x is null - skip
                if (arr[x] == null)
                {
                    continue;
                }
                //if any item has a greater length take its length 
                if (arr[x].Length > val)
                {
                    val = arr[x].Length;
                }
            }

            //create a new appropriately dimensional array
            int?[,] array = new int?[arr.Length, val];

            //cycle through each item in jagged array again 
            for (int x = 0; x < arr.Length; x++)
            {
                //if the unit is null then fill with nulls
                if (arr[x] == null)
                {
                    var y = 0;

                    //while the column index is less than the total number of columns
                    while (y < val)
                    {
                        //set to null 
                        array[x, y] = null;
                        y++;
                    }

                    //skip rest of loop to avoid null eval
                    continue;
                }
                //cycle through each interior array
                for (int y = 0; y < arr[x].Length; y++)
                {
                    //fill two dimensional array
                    array[x, y] = arr[x][y];

                }
            }

            return array;
        }

        /// <summary>
        /// one dimensional array overload
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string getStringOfArray(int[] array)
        {
            var str = $@"{JsonConvert.SerializeObject(array).Trim('[', ']').Replace("[", "{").Replace("]", "}")}";
            return str;
        }

        /// <summary>
        /// String overload
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string getStringOfArray(string[] array)
        {
            var str = $@"{JsonConvert.SerializeObject(array).Trim('[', ']').Replace("[", "{").Replace("]", "}")}";
            return str;
        }


        /// <summary>
        /// Converts the given date value to epoch time.
        /// </summary>
        public static long ToEpochTime(this DateTime dateTime)
        {
            var date = dateTime.ToUniversalTime();
            var ticks = date.Ticks - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).Ticks;
            var ts = ticks / TimeSpan.TicksPerSecond;
            return ts;
        }

        /// <summary>
        /// Converts the given date value to epoch time.
        /// </summary>
        public static long ToEpochTime(this DateTimeOffset dateTime)
        {
            var date = dateTime.ToUniversalTime();
            var ticks = date.Ticks - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero).Ticks;
            var ts = ticks / TimeSpan.TicksPerSecond;
            return ts;
        }

        /// <summary>
        /// Converts the given epoch time to a <see cref="DateTime"/> with <see cref="DateTimeKind.Utc"/> kind.
        /// </summary>
        public static DateTime ToDateTimeFromEpoch(this long intDate)
        {
            var timeInTicks = intDate * TimeSpan.TicksPerSecond;
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(timeInTicks);
        }

        /// <summary>
        /// Converts the given epoch time to a UTC <see cref="DateTimeOffset"/>.
        /// </summary>
        public static DateTimeOffset ToDateTimeOffsetFromEpoch(this long intDate)
        {
            var timeInTicks = intDate * TimeSpan.TicksPerSecond;
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero).AddTicks(timeInTicks);
        }



    }
}