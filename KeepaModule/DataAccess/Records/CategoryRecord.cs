using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Tools;
using static XModule.Constants.Enums;

namespace NtfsModule.DataAccess.Records
{
    /// <summary>
    /// Record type representing an entry in the categories table 
    /// that is derived from a product response
    /// </summary>
    public class CategoryRecord : Record
    {
        /// <summary>
        /// Default constructor for a category record
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="amznCategoryId"></param>
        public CategoryRecord(ulong productId, long? amznCategoryId)
        {
            this.NtfsRecordType = NtfsRecordType.CategoryRecord;
            this.RecordType = RecordType.Ntfs;
            this.ProductId = productId;
            this.AmznCategoryId = amznCategoryId;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        /// <summary>
        /// product id for the associated product record
        /// </summary>
        public ulong ProductId { get; set; }

        /// <summary>
        /// Amzn category id
        /// </summary>
        public long? AmznCategoryId { get; set; }

    }
}
