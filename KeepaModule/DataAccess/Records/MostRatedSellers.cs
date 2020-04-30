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
    /// Record created by utilizing the getTopSellersRequest
    /// </summary>
    public class MostRatedSellersRecord : Record
    {
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="sellerId"></param>
        /// <param name="amznSellerIdentifier"></param>
        public MostRatedSellersRecord(string amznSellerIdentifier)
        {
            this.RecordType = RecordType.Ntfs;
            this.NtfsRecordType = NtfsRecordType.TopSellerRecord;
            this.AmznSellerIdentifier = amznSellerIdentifier;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        /// <summary>
        /// The Amazon Seller Identifier that can be used to search out more data on a seller
        /// </summary>
        public string AmznSellerIdentifier { get; set; }

    }
}
