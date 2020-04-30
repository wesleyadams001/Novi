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
    /// Seller items associated with sellers
    /// </summary>
    public class SellerItemRecord : Record
    {
        /// <summary>
        /// Default constructor for sellerItemRecord
        /// </summary>
        public SellerItemRecord(ulong associatedSeller, string asin, int? asinLastSeen)
        {
            this.RecordType = RecordType.Ntfs;
            this.NtfsRecordType = NtfsRecordType.SellerItemRecord;
            this.AssociatedSeller = associatedSeller;
            this.Asin = asin;
            this.AsinLastSeen = asinLastSeen;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        public ulong AssociatedSeller { get; set; }
        public string Asin { get; set; } = null;
        public int? AsinLastSeen { get; set; } = null;
    }
}
