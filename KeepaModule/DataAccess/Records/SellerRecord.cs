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
    /// A seller record
    /// </summary>
    public class SellerRecord : Record
    {
        /// <summary>
        /// The default constructor for the seller record
        /// In this constructor I cut down the size of the asins array and asinslastseen as
        /// I did not require 100k
        /// </summary>
        public SellerRecord(ulong id, int? domainId, int? trackingSince, int? lastUpdate, string sellerId, string sellerName, bool? isScammer, bool? hasFba, int? storeFrontRecTime, int? totalStoreFrontAsins, int? rating, int? ratingTime, int? ratingCount, int? ratingCountTime)
        {
            this.RecordType = RecordType.Keepa;
            this.KeepaRecordType = KeepaRecordType.SellerRecord;
            this.SellerUid = id;
            this.DomainId = domainId;
            this.TrackingSince = trackingSince;
            this.LastUpdate = lastUpdate;
            this.SellerId = sellerId;
            this.SellerName = sellerName;
            this.IsScammer = isScammer;
            this.HasFba = hasFba;
            //expanded total storefront asins
            this.TotalStoreFrontAsinRecTime = storeFrontRecTime;
            this.TotalStoreFrontAsins = totalStoreFrontAsins;

            this.Rating = rating;
            this.RatingTime = ratingTime;
            this.RatingCount = ratingCount;
            this.RatingCountTime = ratingCountTime;

            this.TimeStamp = Utilities.GetUnixTime();
        }

        public int? DomainId { get; set; }
        public int? TrackingSince { get; set; }
        public int? LastUpdate { get; set; }
        public string SellerId { get; set; }
        public string SellerName { get; set; }
        public bool? IsScammer { get; set; }
        public bool? HasFba { get; set; }
        //public int[] TotalStoreFrontAsins { get; set; } = null;
        public ulong SellerUid { get; set; }
        //total storefront asins expanded
        public int? TotalStoreFrontAsinRecTime { get; set; } = null;
        public int? TotalStoreFrontAsins { get; set; } = null;

        public int? TimeRecordedTotalAsins { get; set; }
        //public int[][] RatingHistoryCsv { get; set; } = null;

        //Expanding the Rating History Csv into a form that conforms
        // to a relational model
        public int? Rating { get; set; } = null;
        public int? RatingTime { get; set; } = null;
        public int? RatingCount { get; set; } = null;
        public int? RatingCountTime { get; set; } = null;

        

    }
}
