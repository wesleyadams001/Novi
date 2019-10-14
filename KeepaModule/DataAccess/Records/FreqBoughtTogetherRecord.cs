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
    /// A frequently bought together record
    /// </summary>
    public class FreqBoughtTogetherRecord : Record
    {
        /// <summary>
        /// The default constructor for frequently purchased together record
        /// </summary>
        /// <param name="firstAsin"></param>
        /// <param name="secondAsin"></param>
        public FreqBoughtTogetherRecord(ulong productId, string associatedAsin)
        {
            this.RecordType = RecordType.Keepa;
            this.KeepaRecordType = KeepaRecordType.FrequentlyBoughtTogetherRecord;
            this.ProductId = productId;
            this.AssociatedAsin = associatedAsin;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        public ulong ProductId {get;set;}
        public string AssociatedAsin { get; set; }
    }
}
