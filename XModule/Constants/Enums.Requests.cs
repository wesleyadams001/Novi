using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Constants
{
    public static partial class Enums
    {
        /// <summary>
        /// Enumeration that represents the request types at the API level
        /// </summary>
        public enum RequestTypes
        {
            Default = -1,
            [Description("Ntfs")]
            Ntfs =0,
            [Description("Doba")]
            Doba =1
        }
    }
}
