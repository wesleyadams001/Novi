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
    /// A UPC record
    /// </summary>
    public class UpcRecord : Record
    {
        /// <summary>
        /// The Default constructor for UPC record
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="upcNumber"></param>
        public UpcRecord(ulong productId, string upcNumber)
        {
            this.RecordType = RecordType.Keepa;
            this.KeepaRecordType = KeepaRecordType.UpcRecord;
            this.ProductId = productId;
            this.UpcNumber = upcNumber;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        public ulong ProductId { get; set; }
        public string UpcNumber { get; set; }
    }
}
