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
    /// An EAN Record
    /// </summary>
    public class EanRecord : Record
    {
        /// <summary>
        /// Default record constructor
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="eanNumber"></param>
        public EanRecord(ulong productId, string eanNumber)
        {
            this.KeepaRecordType = KeepaRecordType.EanRecord;
            this.RecordType = RecordType.Keepa;
            this.ProductId = productId;
            this.EanNumber = eanNumber;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        public ulong ProductId { get; set; }
        public string EanNumber { get; set; }

    }
}
