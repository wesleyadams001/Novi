using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtfsModule.Models
{
    /// <summary>
    /// Contains statistic values.
    /// Only set if the stats parameter was used in the Product Request. Part of the {@link Product}
    /// </summary>
    public class Stats
    {

        /// <summary>
        /// Contains the prices / ranks of the product of the time we last updated it.
        /// <p>Uses {@link Product.CsvType} indexing.</p>
        /// The price is an integer of the respective Amazon locale's smallest currency unit (e.g. euro cents or yen).
        /// If no offer was available in the given interval (e.g. out of stock) the price has the value -1.
        ///</summary>
        public int[] current = null;

        /// <summary>
        /// Contains the weighted mean for the interval specified in the product request's stats parameter.<br>
        /// <p>Uses {@link Product.CsvType} indexing.</p>
        /// If no offer was available in the given interval or there is insufficient data it has the value -1.
        ///</summary>
        public int[] avg = null;


        /// <summary>
        /// Contains the weighted mean for the last 30 days.<br>
        /// <p>Uses {@link Product.CsvType} indexing.</p>
        /// If no offer was available in the given interval or there is insufficient data it has the value -1.
        ///</summary>
        public int[] avg30 = null;


        /// <summary>
        /// Contains the weighted mean for the last 90 days.<br>
        /// <p>Uses {@link Product.CsvType} indexing.</p>
        /// If no offer was available in the given interval or there is insufficient data it has the value -1.
        ///</summary>
        public int[] avg90 = null;

        /// <summary>
        /// Contains the weighted mean for the last 180 days.<br>
        /// <p>Uses {@link Product.CsvType} indexing.</p>
        /// If no offer was available in the given interval or there is insufficient data it has the value -1.
        ///</summary>
        public int[] avg180 = null;

        /// <summary>
        /// Contains the prices registered at the start of the interval specified in the product request's stats parameter.<br>
        /// <p>Uses {@link Product.CsvType} indexing.</p>
        /// If no offer was available in the given interval or there is insufficient data it has the value -1.
        ///</summary>
        public int[] atIntervalStart = null;

        /// <summary>
        /// Contains the lowest prices registered for this product. <br>
        /// First dimension uses {@link Product.CsvType} indexing <br>
        /// Second dimension is either null, if there is no data available for the price type, or
        /// an array of the size 2 with the first value being the time of the extreme point (in Ntfs time minutes) and the second one the respective extreme value.
        /// <br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        ///</summary>
        public int[][] min = null;

        /// <summary>
        /// Contains the lowest prices registered in the interval specified in the product request's stats parameter.<br>
        /// First dimension uses {@link Product.CsvType} indexing <br>
        /// Second dimension is either null, if there is no data available for the price type, or
        /// an array of the size 2 with the first value being the time of the extreme point (in Ntfs time minutes) and the second one the respective extreme value.
        /// <br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        ///</summary>
        public int[][] minInInterval = null;

        /// <summary>
        /// Contains the highest prices registered for this product. <br>
        /// First dimension uses {@link Product.CsvType} indexing <br>
        /// Second dimension is either null, if there is no data available for the price type, or
        /// an array of the size 2 with the first value being the time of the extreme point (in Ntfs time minutes) and the second one the respective extreme value.<br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        ///</summary>
        public int[][] max = null;

        /// <summary>
        /// Contains the highest prices registered in the interval specified in the product request's stats parameter.<br>
        /// First dimension uses {@link Product.CsvType} indexing <br>
        /// Second dimension is either null, if there is no data available for the price type, or
        /// an array of the size 2 with the first value being the time of the extreme point (in Ntfs time minutes) and the second one the respective extreme value.<br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        ///</summary>
        public int[][] maxInInterval = null;

        /// <summary>
        /// Contains the out of stock percentage in the interval specified in the product request's stats parameter.<br>
        /// <p>Uses {@link Product.CsvType} indexing.</p>
        /// It has the value -1 if there is insufficient data or the CsvType is not a price.<br>
        /// <p>Examples: 0 = never was out of stock, 100 = was out of stock 100% of the time, 25 = was out of stock 25% of the time</p>
        ///</summary>
        public int[] outOfStockPercentageInInterval = null;

        /// <summary>
        /// Contains the 90 day out of stock percentage<br>
        /// <p>Uses {@link Product.CsvType} indexing.</p>
        /// It has the value -1 if there is insufficient data or the CsvType is not a price.<br>
        /// <p>Examples: 0 = never was out of stock, 100 = was out of stock 100% of the time, 25 = was out of stock 25% of the time</p>
        ///</summary>
        public int[] outOfStockPercentage90 = null;

        /// <summary>
        /// Contains the 30 day out of stock percentage<br>
        /// <p>Uses {@link Product.CsvType} indexing.</p>
        /// It has the value -1 if there is insufficient data or the CsvType is not a price.<br>
        /// <p>Examples: 0 = never was out of stock, 100 = was out of stock 100% of the time, 25 = was out of stock 25% of the time</p>
        ///</summary>
        public int[] outOfStockPercentage30 = null;

        /// <summary>
        /// Can be used to identify past, upcoming and current lightning deal offers.<br>
        /// Has the format [startDate, endDate] (if not null, always array length 2). ///null/// if the product never had a lightning deal. Both timestamps are in UTC and Ntfs time minutes.<br>
        /// If there is a upcoming lightning deal, only startDate is be set (endDate has value -1)<br>
        /// If there is a current lightning deal, both startDate and endDate will be set. startDate will be older than the current time, but endDate will be a future date.<br>
        /// If there is only a past deal, both startDate and endDate will be set in the past.<br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        ///</summary>
        public int[] lightningDealInfo = null; // [startDate, endDate], or null

        /// <summary>
        /// the total count of offers this product has (all conditions combined). The offer count per condition can be found in the current field.
        ///</summary>
        public int totalOfferCount = -2;

        /// <summary>
        /// the last time the offers information was updated. Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        ///</summary>
        public int lastOffersUpdate = -1;

        /// <summary>
        /// Contains the total stock available per item condition (of the retrieved offers) for 3rd party FBA
        /// (fulfillment by Amazon, Warehouse Deals included) or FBM (fulfillment by merchant) offers. Uses the {@link Offer.OfferCondition} indexing.
        ///</summary>
        public int[] stockPerCondition3rdFBA = null;

        /// <summary>
        /// Contains the total stock available per item condition (of the retrieved offers) for 3rd party FBM
        /// (fulfillment by Amazon, Warehouse Deals included) or FBM (fulfillment by merchant) offers. Uses the {@link Offer.OfferCondition} indexing.
        ///</summary>
        public int[] stockPerConditionFBM = null;

        /// <summary>
        /// Only set when the offers parameter was used. The stock of Amazon, if Amazon has an offer. Max. reported stock is 10. Otherwise -2.
        ///</summary>
        public int stockAmazon = -2;

        /// <summary>
        /// Only set when the offers parameter was used. The stock of buy box offer. Max. reported stock is 10. If the boy box is empty/unqualified: -2.
        ///</summary>
        public int stockBuyBox = -2;

        /// <summary>
        /// Only set when the offers parameter was used. The count of actually retrieved offers for this request.
        ///</summary>
        public int retrievedOfferCount = -2;

        /// <summary>
        /// Only set when the offers parameter was used. The buy box price, if existent. Otherwise -2.
        ///</summary>
        public int buyBoxPrice = -2;

        /// <summary>
        /// Only set when the offers parameter was used. The buy box shipping cost, if existent. Otherwise -2.
        ///</summary>
        public int buyBoxShipping = -2;

        /// <summary>
        /// Only set when the offers parameter was used. Whether or not a seller won the buy box. If there are only sellers with bad offers none qualifies for the buy box.
        ///</summary>
        public bool? buyBoxIsUnqualified = false;

        /// <summary>
        /// Only set when the offers parameter was used. Whether or not the buy box is listed as being shippable.
        ///</summary>
        public bool? buyBoxIsShippable = false;

        /// <summary>
        /// Only set when the offers parameter was used. If the buy box is a pre-order.
        ///</summary>
        public bool? buyBoxIsPreorder = false;

        /// <summary>
        /// Only set when the offers parameter was used. Whether or not the buy box is fulfilled by Amazon.
        ///</summary>
        public bool? buyBoxIsFBA = false;

        /// <summary>
        /// Only set when the offers parameter was used. Whether or not the buy box offer is in used condition.
        ///</summary>
        public bool? buyBoxIsUsed = false;

        /// <summary>
        /// Only set when the offers parameter was used. If Amazon is the seller in the buy box.
        ///</summary>
        public bool? buyBoxIsAmazon = false;

        /// <summary>
        /// Only set when the offers parameter was used. If the buy box price is hidden on Amazon due to MAP restrictions (minimum advertised price).
        ///</summary>
        public bool? buyBoxIsMAP = false;

        /// <summary>
        /// Only set when the offers parameter was used. If the product is an add-on item (add-on Items ship with orders that include $25 or more of items shipped by Amazon).
        ///</summary>
        public bool? isAddonItem = false;

        /// <summary>
        /// Only set when the offers parameter was used. Contains the seller ids (if any) of the lowest priced live FBA offer(s). Multiple entries if multiple offers share the same price.
        ///</summary>
        public String[] sellerIdsLowestFBA = null;

        /// <summary>
        /// Only set when the offers parameter was used. Contains the seller ids (if any) of the lowest priced live FBM offer(s). Multiple entries if multiple offers share the same price.
        ///</summary>
        public String[] sellerIdsLowestFBM = null;

        /// <summary>
        /// Only set when the offers parameter was used. Count of retrieved live FBA offers.
        ///</summary>
        public int offerCountFBA = -2;

        /// <summary>
        /// Only set when the offers parameter was used. Count of retrieved live FBM offers.
        ///</summary>
        public int offerCountFBM = -2;

        /// <summary>
        /// Override of the To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
