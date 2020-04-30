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
    /// A Features Record from the response objects product property
    /// </summary>
    public class FeaturesRecord : Record
    {
        /// <summary>
        /// Default features record constructor
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="features"></param>
        public FeaturesRecord(ulong productId, string features)
        {
            this.RecordType = RecordType.Ntfs;
            this.NtfsRecordType = NtfsRecordType.FeaturesRecord;
            this.ProductId = productId;
            this.Features = features;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        public ulong ProductId { get; set; }
        public string Features { get; set; }
    }
}
