using System;
using System.Collections.Generic;
using System.Text;
using static XModule.Constants.Enums;
using XModule.Tools;
using Newtonsoft.Json;

namespace NtfsModule.DataAccess.Records
{
    /// <summary>
    /// A Record generated from a best sellers response object
    /// A single response object can contain very many Best Seller Records
    /// As the response object contains an ordered list of Asins
    /// starting with the best selling item
    /// </summary>
    public class BestSellerRecord : Record
    {
        /// <summary>
        /// Basic Constructor for best seller record object
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="categoryId"></param>
        /// <param name="asinList"></param>
        public BestSellerRecord(int? domainId, int? lastUpdate, long? categoryId, string asin)
        {
            RecordType = RecordType.Ntfs;
            NtfsRecordType = NtfsRecordType.BestSellerRecord;
            DomainId = domainId;
            LastUpdate = lastUpdate;
            CategoryId = categoryId;
            Asin = asin;
            TimeStamp = Utilities.GetUnixTime();
        }

        /// <summary>
        /// Integer value for the Amazon locale this list belong?s to.
        /// Possible values: [ 1: com | 2: co.uk 6 | 3: de | 4: fr | 5: co.jp | 6: ca | 7: cn | 8: it | 9: es | 10: in ]
        /// </summary>
        public int? DomainId { get; set; }

        /// <summary>
        /// States the last time Ntfs updated the list, Ntfs Time minutes translated to Unix Time
        /// </summary>
        public int? LastUpdate { get; set; }

        /// <summary>
        /// The category node id used in the request. Represents the identifier of the category.
        /// Example: 281052 - http://www.amazon.com/b/?node=281052 187
        /// </summary>
        public long? CategoryId { get; set; }

        /// <summary>
        /// An ASIN list. The list starts with the best selling product (lowest sales rank).
        /// </summary>
        public string Asin { get; set; }

        public override string ToString()
        {
            var str = base.ToString();
            return str;
        }
    }
}
