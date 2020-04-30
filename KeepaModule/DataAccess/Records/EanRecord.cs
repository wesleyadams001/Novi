using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XModule.Constants.Enums;
using XModule.Tools;

namespace NtfsModule.DataAccess.Records
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
            this.NtfsRecordType = NtfsRecordType.EanRecord;
            this.RecordType = RecordType.Ntfs;
            this.ProductId = productId;
            this.EanNumber = eanNumber;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        public ulong ProductId { get; set; }
        public string EanNumber { get; set; }

    }
}
