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
    /// A Price History Record from the response objects product property
    /// </summary>
    public class PriceHistoryRecord : Record
    {
        /// <summary>
        /// The default constructor for a price history record
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="recordedTime"></param>
        public PriceHistoryRecord(ulong productId, int histType, long date, int price)
        {
            this.RecordType = RecordType.Keepa;
            this.KeepaRecordType = KeepaRecordType.PriceHistoryRecord;
            this.ProductId = productId;
            this.obHistoryType = histType;
            this.obDate = date;
            this.obPrice = price;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        /// <summary>
        /// The constructor for a price history record that is a *_SHIPPING array
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="histType"></param>
        /// <param name="date"></param>
        /// <param name="price"></param>
        public PriceHistoryRecord(ulong productId, int histType, long date, int price, int? shipping)
        {
            this.RecordType = RecordType.Keepa;
            this.KeepaRecordType = KeepaRecordType.PriceHistoryRecord;
            this.ProductId = productId;
            this.obHistoryType = histType;
            this.obDate = date;
            this.obPrice = price;
            this.obShipping = shipping;
            this.TimeStamp = Utilities.GetUnixTime();
        }
        /// <summary>
        /// An integer 0-31 that corresponds to a csv/history type
        /// </summary>
        public int obHistoryType { get; set; }

        /// <summary>
        /// A ulong that represents a product ID
        /// </summary>
        public ulong ProductId { get; set; }

        /// <summary>
        /// The observed date
        /// </summary>
        public long obDate { get; set; }

        /// <summary>
        /// The observed price
        /// </summary>
        public int obPrice { get; set; }

        /// <summary>
        /// The observed shipping
        /// </summary>
        public int? obShipping { get; set; }

    }
}
