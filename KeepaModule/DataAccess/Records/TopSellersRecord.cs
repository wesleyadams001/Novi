using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XModule.Constants.Enums;
using XModule.Tools;

namespace NtfsModule.DataAccess.Records
{
    public class TopSellersRecord : Record
    {
        /// <summary>
        /// Constructor for Top seller record
        /// </summary>
        /// <param name="sellerId"></param>
        /// <param name="name"></param>
        /// <param name="rating"></param>
        /// <param name="reviewCntTotal"></param>
        /// <param name="reviewCntL30"></param>
        /// <param name="usesFBA"></param>
        /// <param name="verifiedListings"></param>
        /// <param name="primarySales"></param>
        /// <param name="timeStamp"></param>
        public TopSellersRecord(int? sellerId, string name, double? rating, int? reviewCntTotal, int? reviewCntL30, bool? usesFBA, int? verifiedListings, string primarySales)
        {
            this.RecordType = RecordType.Ntfs;
            this.NtfsRecordType = NtfsRecordType.TopSellerRecord;
            this.SellerId = sellerId;
            this.Name = name;
            this.Rating = rating;
            this.ReviewCntTotal = reviewCntTotal;
            this.ReviewCntL30 = reviewCntL30;
            this.UsesFBA = usesFBA;
            this.VerifiedListings = verifiedListings;
            this.PrimarySales = primarySales;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        /// <summary>
        /// Sellers unique identification number
        /// </summary>
        public int? SellerId { get; set; }

        /// <summary>
        /// sellers Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// sellers rating
        /// </summary>
        public double? Rating { get; set; }

        /// <summary>
        /// seller's total review count
        /// </summary>
        public int? ReviewCntTotal { get; set; }

        /// <summary>
        /// sellers total review count for the last 30 days
        /// </summary>
        public int? ReviewCntL30 { get; set; }

        /// <summary>
        /// whether the seller uses FBA
        /// </summary>
        public bool? UsesFBA { get; set; }

        /// <summary>
        /// Number of verified listings
        /// </summary>
        public int? VerifiedListings { get; set; }

        /// <summary>
        /// the primary sales category
        /// </summary>
        public string PrimarySales { get; set; }


    }
}
