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
    /// An FBA Fees record
    /// </summary>
    public class FbaFeesRecord : Record
    {
        /// <summary>
        /// Default constructor for FBA Fees Record
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="pickPackFee"></param>
        /// <param name="pickPackFeeTax"></param>
        /// <param name="storageFee"></param>
        /// <param name="storageFeeTax"></param>
        public FbaFeesRecord(ulong productId, int? pickPackFee, int? pickPackFeeTax, int? storageFee, int? storageFeeTax)
        {
            this.RecordType = RecordType.Keepa;
            this.KeepaRecordType = KeepaRecordType.FbaFeesRecord;
            this.ProductId = productId;
            this.PickPackFee = pickPackFee;
            this.PickPackFeeTax = pickPackFeeTax;
            this.StorageFee = storageFee;
            this.StorageFeeTax = storageFeeTax;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        public ulong ProductId { get; set; }
        public int? PickPackFee { get; set; }
        public int? PickPackFeeTax { get; set; }
        public int? StorageFee { get; set; }
        public int? StorageFeeTax { get; set; }
    }
}
