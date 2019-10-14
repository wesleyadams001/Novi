using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XModule.Constants.Enums;
using XModule.Tools;

namespace KeepaModule.DataAccess.Records
{
    /// <summary>
    /// A Variation Record
    /// Only appearing in parent ASINS
    /// Usually contains around 50 items
    /// </summary>
    public class VariationRecord : Record
    {
        public ulong productId { get; set; }
        public string Variation { get; set; }
        public string vDimension { get; set; }
        public string vValue { get; set; }


        /// <summary>
        /// Default constructor for a variation object
        /// </summary>
        /// <param name="variationOne"></param>
        /// <param name="variationTwo"></param>
        public VariationRecord(ulong productId, string variation, string dimension, string value)
        {
            this.RecordType = RecordType.Keepa;
            this.KeepaRecordType = KeepaRecordType.VariationsRecord;
            this.productId = productId;
            this.Variation = variation;
            this.vDimension = dimension;
            this.vValue = value;
            this.TimeStamp = Utilities.GetUnixTime();
            
        }
    }
}
