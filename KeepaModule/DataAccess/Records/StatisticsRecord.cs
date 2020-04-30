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
    /// A statistics record
    /// </summary>
    public class StatisticsRecord : Record
    {
        /// <summary>
        /// Default constructor for statistics record
        /// </summary>
        /// <param name="current"></param>
        /// <param name="avg"></param>
        /// <param name="avg30"></param>
        /// <param name="avg90"></param>
        /// <param name="avg180"></param>
        /// <param name="atIntervalStart"></param>
        /// <param name="minTwoDimensional"></param>
        /// <param name="maxTwoDimensional"></param>
        /// <param name="minInIntervalTwoDimensional"></param>
        /// <param name="maxInIntervalTwoDimensional"></param>
        /// <param name="outOfStockPercentageInInterval"></param>
        /// <param name="outOfStockPercentage30"></param>
        /// <param name="outOfStockPercentage90"></param>
        /// <param name="lastOffersUpdate"></param>
        /// <param name="totalOffersCount"></param>
        /// <param name="lightningDealInfo"></param>
        /// <param name="retrievedOfferCount"></param>
        /// <param name="buyBoxPrice"></param>
        /// <param name="buyBoxShipping"></param>
        /// <param name="buyBoxIsUnqualified"></param>
        /// <param name="buyBoxIsShippable"></param>
        /// <param name="buyBoxIsPreorder"></param>
        /// <param name="buyBoxIsFba"></param>
        /// <param name="buyBoxIsAmazon"></param>
        /// <param name="buyBoxIsMap"></param>
        /// <param name="buyBoxIsUsed"></param>
        /// <param name="isAddOnItem"></param>
        /// <param name="sellerIdsLowestFba"></param>
        /// <param name="sellerIdsLowestFbm"></param>
        /// <param name="offerCountFba"></param>
        /// <param name="offerCountFbm"></param>
        public StatisticsRecord(ulong productId, int? statType, int? current, int? avg, int? avg30, int? avg90, int? avg180, int? atIntervalStart, int? minPriceType, int? minPriceRecTime, int? minPriceValue, int? maxPriceType, int? maxPriceRecTime, int? maxPriceValue, int? minIntervalPriceType, int? minIntervalPriceRecTime, int? minIntervalPriceValue, int? maxIntervalPriceType, int? maxIntervalPriceRecTime, int? maxIntervalPriceValue, int? outOfStockPercentageInInterval, int? outOfStockPercentage30, int? outOfStockPercentage90, int? lastOffersUpdate, int? totalOffersCount, int? lightningDealInfo, int? retrievedOfferCount, int? buyBoxPrice, int? buyBoxShipping, bool? buyBoxIsUnqualified, bool? buyBoxIsShippable, bool? buyBoxIsPreorder, bool? buyBoxIsFba, bool? buyBoxIsAmazon, bool? buyBoxIsMap, bool? buyBoxIsUsed, bool? isAddOnItem, string sellerIdsLowestFba, string sellerIdsLowestFbm, int? offerCountFba, int? offerCountFbm)
        {
            this.RecordType = RecordType.Ntfs;
            this.NtfsRecordType = NtfsRecordType.StatisitcsRecord;
            this.ProductId = productId;
            this.StatType = statType;
            this.Current = current;
            this.Avg = avg;
            this.Avg30 = avg30;
            this.Avg90 = avg90;
            this.Avg180 = avg180;
            this.AtIntervalStart = atIntervalStart;
            //this.MinTwoDimensional = minTwoDimensional;
            //this.MaxTwoDimensional = maxTwoDimensional;

            this.MinPriceType = minPriceType;
            this.MinPriceRecTime = minPriceRecTime;
            this.MinPriceValue = minPriceValue;

            this.MaxPriceType = maxPriceType;
            this.MaxPriceRecTime = maxPriceRecTime;
            this.MaxPriceValue = maxPriceValue;

            //this.MinInIntervalTwoDimensional = minInIntervalTwoDimensional;
            //this.MaxInIntervalTwoDimensional = maxInIntervalTwoDimensional;

            this.IntervalMinPriceType = minIntervalPriceType;
            this.IntervalMinPriceRecTime = minIntervalPriceRecTime;
            this.IntervalMinPriceValue = minIntervalPriceValue;

            this.IntervalMaxPriceType = maxIntervalPriceType;
            this.IntervalMaxPriceRecTime = maxIntervalPriceRecTime;
            this.IntervalMaxPriceValue = maxIntervalPriceValue;

            this.OutOfStockPercentageInInterval = outOfStockPercentageInInterval;
            this.OutOfStockPercentage30 = outOfStockPercentage30;
            this.OutOfStockPercentage90 = outOfStockPercentage90;
            this.LastOffersUpdate = lastOffersUpdate;
            this.TotalOffersCount = totalOffersCount;
            this.LightningDealInfo = lightningDealInfo;
            this.RetrievedOfferCount = retrievedOfferCount;
            this.BuyBoxPrice = buyBoxPrice;
            this.BuyBoxShipping = buyBoxShipping;
          
            this.BuyBoxIsUnqualified = buyBoxIsUnqualified;
            this.BuyBoxIsShippable = buyBoxIsShippable;
            this.BuyBoxIsPreorder = buyBoxIsPreorder;
            this.BuyBoxIsFba = buyBoxIsFba;
            this.BuyBoxIsAmazon = buyBoxIsAmazon;
            this.BuyBoxIsMap = buyBoxIsMap;
            this.BuyBoxIsUsed = buyBoxIsUsed;
            this.IsAddOnItem = isAddOnItem;
            this.SellerIdsLowestFba = sellerIdsLowestFba;
            this.SellerIdsLowestFbm = sellerIdsLowestFbm;
            this.OfferCountFba = offerCountFba;
            this.OfferCountFbm = offerCountFbm;
            this.TimeStamp = Utilities.GetUnixTime();
        }
        public ulong ProductId { get; set; }
        public int? StatType { get; set; }
        public int? Current { get; set; }
        public int? Avg { get; set; }
        public int? Avg30 { get; set; }
        public int? Avg90 { get; set; }
        public int? Avg180 { get; set; }
        public int? AtIntervalStart { get; set; }
        //public int? MinTwoDimensional { get; set; }
        //public int? MaxTwoDimensional { get; set; }

        /// <summary>
        /// splits min two dimensional into respective relational components
        /// a Piece of minTwoDimensional: a counter value based on first dimension to indicate price type
        /// </summary>
        public int? MinPriceType { get; set; }

        /// <summary>
        /// splits min two dimensional into respective relational components
        /// a Piece of minTwoDimensional: either the time the price was recorded or null
        /// </summary>
        public int? MinPriceRecTime { get; set; }

        /// <summary>
        /// splits min two dimensional into respective relational components
        /// a Piece of minTwoDimensional: either the value of the price or null
        /// </summary>
        public int? MinPriceValue { get; set; }

        /// <summary>
        /// splits max two dimensional into respective relational components
        /// a Piece of maxTwoDimensional: a counter value based on first dimension to indicate price type
        /// </summary>
        public int? MaxPriceType { get; set; }

        /// <summary>
        /// splits max two dimensional into respective relational components
        /// a Piece of maxTwoDimensional: either the time the price was recorded or null
        /// </summary>
        public int? MaxPriceRecTime { get; set; }

        /// <summary>
        /// splits max two dimensional into respective relational components
        /// a Piece of maxTwoDimensional: either the value of the price or null
        /// </summary>
        public int? MaxPriceValue { get; set; }

        //public int? MinInIntervalTwoDimensional { get; set; }
        //public int? MaxInIntervalTwoDimensional { get; set; }

        /// <summary>
        /// splits min two dimensional interval adjusted array into respective relational components
        /// a Piece of minTwoDimensional: a counter value based on first dimension to indicate price type
        /// </summary>
        public int? IntervalMinPriceType { get; set; }

        /// <summary>
        /// splits min two dimensional interval adjusted array into respective relational components
        /// a Piece of minTwoDimensional: either the time the price was recorded or null
        /// </summary>
        public int? IntervalMinPriceRecTime { get; set; }

        /// <summary>
        /// splits min two dimensional interval adjusted array into respective relational components
        /// a Piece of minTwoDimensional: either the value of the price or null
        /// </summary>
        public int? IntervalMinPriceValue { get; set; }

        /// <summary>
        /// splits max two dimensional interval adjusted array into respective relational components
        /// a Piece of maxTwoDimensional: a counter value based on first dimension to indicate price type
        /// </summary>
        public int? IntervalMaxPriceType { get; set; }

        /// <summary>
        /// splits max two dimensional interval adjusted array into respective relational components
        /// a Piece of maxTwoDimensional: either the time the price was recorded or null
        /// </summary>
        public int? IntervalMaxPriceRecTime { get; set; }

        /// <summary>
        /// splits max two dimensional interval adjusted array into respective relational components
        /// a Piece of maxTwoDimensional: either the value of the price or null
        /// </summary>
        public int? IntervalMaxPriceValue { get; set; }

        public int? OutOfStockPercentageInInterval { get; set; }
        public int? OutOfStockPercentage30 { get; set; }
        public int? OutOfStockPercentage90 { get; set; }
        public int? LastOffersUpdate { get; set; } = null;
        public int? TotalOffersCount { get; set; } = null;
        public int? LightningDealInfo { get; set; }

        //THE FOLLOWING FIELDS ARE ONLY SET IF THE OFFERS PARAMETER WAS USED

        public int? RetrievedOfferCount { get; set; } = null;
        public int? BuyBoxPrice { get; set; } = null;
        public int? BuyBoxShipping { get; set; } = null;
        public bool? BuyBoxIsUnqualified { get; set; } = false;
        public bool? BuyBoxIsShippable { get; set; } = false;
        public bool? BuyBoxIsPreorder { get; set; } = false;
        public bool? BuyBoxIsFba { get; set; } = false;
        public bool? BuyBoxIsAmazon { get; set; } = false;
        public bool? BuyBoxIsMap { get; set; } = false;
        public bool? BuyBoxIsUsed { get; set; } = false;
        public bool? IsAddOnItem { get; set; } = false;
        public string SellerIdsLowestFba { get; set; } = null;
        public string SellerIdsLowestFbm { get; set; } = null;
        public int? OfferCountFba  { get; set; } = null;
        public int? OfferCountFbm  { get; set; } = null;
    }
}
