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
        /// Record factory type
        /// ~This will have to move~
        /// </summary>
        public enum RecordFactoryType
        {
            [Description("Ntfs")]
            Ntfs =0,
            [Description("Doba")]
            Doba =1
        }
    }
}
