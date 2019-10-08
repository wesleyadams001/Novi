using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Constants
{
    public static partial class Enums
    {
        /// <summary>
        /// Enum to indicate the availability
        /// </summary>
        public enum AvailabilityType
        {
            /// <summary>
            /// No Amazon offer exists
            /// </summary>
            NO_OFFER,

            /// <summary>
            /// Amazon offer is in stock and shippable
            /// </summary>
            NOW,

            /// <summary>
            /// Amazon offer is currently not in stock but will be in the future (i.e. back-ordered, pre-order)
            /// </summary>
            FUTURE,

            /// <summary>
            /// Amazon offer availability is "unknown"
            /// </summary>
            UNKNOWN,

            /// <summary>
            /// Unrecognized Amazon availability status
            /// </summary>
            OTHER
        }

        /// <summary>
        /// Enum to indicate CSV type
        /// </summary>
        public enum CsvType
        {
            /// <summary>
            /// Amazon price history
            /// </summary>
            AMAZON,

            /// <summary>
            /// Marketplace/3rd party New price history - Amazon is considered to be part of the marketplace as well,
            /// so if Amazon has the overall lowest new (!) price, the marketplace new price in the corresponding time interval
            /// will be identical to the Amazon price (except if there is only one marketplace offer).
            /// Shipping and Handling costs not included!
            /// </summary>
            NEW,

            /// <summary>
            /// Marketplace/3rd party Used price history
            /// </summary>
            USED,

            /// <summary>
            /// Sales Rank history. Not every product has a Sales Rank.
            /// </summary>
            SALES,

            /// <summary>
            /// List Price history
            /// </summary>
            LIST_PRICE,

            /// <summary>
            /// Collectible Price history
            /// </summary>
            COLLECTIBLE,

            /// <summary>
            /// Refurbished Price history
            /// </summary>
            REFURBISHED,

            /// <summary>
            /// 3rd party (not including Amazon) New price history including shipping costs, only fulfilled by merchant (FBM).
            /// </summary>
            NEW_FBM_SHIPPING,

            /// <summary>
            /// 3rd party (not including Amazon) New price history including shipping costs, only fulfilled by merchant (FBM).
            /// </summary>
            LIGHTNING_DEAL,

            /// <summary>
            /// Amazon Warehouse Deals price history. Mostly of used condition, rarely new.
            /// </summary>
            WAREHOUSE,

            /// <summary>
            /// Price history of the lowest 3rd party (not including Amazon/Warehouse) New offer that is fulfilled by Amazon
            /// </summary>
            NEW_FBA,

            /// <summary>
            /// New offer count history
            /// </summary>
            COUNT_NEW,

            /// <summary>
            /// Used offer count history
            /// </summary>
            COUNT_USED,

            /// <summary>
            /// Refurbished offer count history
            /// </summary>
            COUNT_REFURBISHED,

            /// <summary>
            /// Collectible offer count history
            /// </summary>
            COUNT_COLLECTIBLE,

            /// <summary>
            /// History of past updates to all offers-parameter related data: offers, buyBoxSellerIdHistory, isSNS, isRedirectASIN and the csv types
            /// NEW_SHIPPING, WAREHOUSE, FBA, BUY_BOX_SHIPPING, USED_///_SHIPPING, COLLECTIBLE_///_SHIPPING and REFURBISHED_SHIPPING.
            /// As updates to those fields are infrequent it is important to know when our system updated them.
            /// The absolute value indicates the amount of offers fetched at the given time.
            /// If the value is positive it means all available offers were fetched. It's negative if there were more offers than fetched.
            /// </summary>
            EXTRA_INFO_UPDATES,

            /// <summary>
            /// The product's rating history. A rating is an integer from 0 to 50 (e.g. 45 = 4.5 stars)
            /// </summary>
            RATING,

            /// <summary>
            /// The product's review count history.
            /// </summary>
            COUNT_REVIEWS,

            /// <summary>
            /// The price history of the buy box. If no offer qualified for the buy box the price has the value -1. Including shipping costs.
            /// </summary>
            BUY_BOX_SHIPPING,

            /// <summary>
            /// "Used - Like New" price history including shipping costs.
            /// </summary>
            USED_NEW_SHIPPING,

            /// <summary>
            /// "Used - Very Good" price history including shipping costs.
            /// </summary>
            USED_VERY_GOOD_SHIPPING,

            /// <summary>
            /// "Used - Good" price history including shipping costs.
            /// </summary>
            USED_GOOD_SHIPPING,

            /// <summary>
            /// "Used - Acceptable" price history including shipping costs.
            /// </summary>
            USED_ACCEPTABLE_SHIPPING,

            /// <summary>
            /// "Collectible - Like New" price history including shipping costs.
            /// </summary>
            COLLECTIBLE_NEW_SHIPPING,

            /// <summary>
            /// "Collectible - Very Good" price history including shipping costs.
            /// </summary>
            COLLECTIBLE_VERY_GOOD_SHIPPING,

            /// <summary>
            /// "Collectible - Good" price history including shipping costs.
            /// </summary>
            COLLECTIBLE_GOOD_SHIPPING,

            /// <summary>
            /// "Collectible - Acceptable" price history including shipping costs.
            /// </summary>
            COLLECTIBLE_ACCEPTABLE_SHIPPING,
            /// <summary>
            /// Refurbished price history including shipping costs.
            /// </summary>
            REFURBISHED_SHIPPING,

            /// <summary>
            /// price history of the lowest new price on the respective eBay locale, including shipping costs.
            /// </summary>
            EBAY_NEW_SHIPPING,

            /// <summary>
            /// price history of the lowest used price on the respective eBay locale, including shipping costs.
            /// </summary>
            EBAY_USED_SHIPPING,

            /// <summary>
            /// The trade in price history. Amazon trade-in is not available for every locale.
            /// </summary>
            TRADE_IN,

            /// <summary>
            /// Rental price history. Requires use of the rental and offers parameter. Amazon Rental is only available for Amazon US.
            /// </summary>
            RENT

        }

        /// <summary>
        /// Available deal ranges.
        /// </summary>
        public enum DealInterval
        {
            DAY,
            WEEK,
            MONTH,
            _90_DAYS
        }

        /// <summary>
        /// Indicates the hazardous material type
        /// </summary>
        public enum HazardousMaterialType
        {
            /// <summary>
            /// Default
            /// </summary>
            DEFAULT = -1,

            /// <summary>
            /// "ORM-D Class"
            /// </summary>
            ORM_D_Class = 0,

            /// <summary>
            /// "ORM-D Class 1"
            /// </summary>
            ORM_D_Class_1,

            /// <summary>
            /// "ORM-D Class 2"
            /// </summary>
            ORM_D_Class_2,

            /// <summary>
            /// "ORM-D Class 3"
            /// </summary>
            ORM_D_Class_3,

            /// <summary>
            /// "ORM-D Class 4"
            /// </summary>
            ORM_D_Class_4,

            /// <summary>
            /// "ORM-D Class 5"
            /// </summary>
            ORM_D_Class_5,

            /// <summary>
            /// "ORM-D Class 6"
            /// </summary>
            ORM_D_Class_6,

            /// <summary>
            /// "ORM-D Class 7"
            /// </summary>
            ORM_D_Class_7,

            /// <summary>
            /// "ORM-D Class 8"
            /// </summary>
            ORM_D_Class_8,

            /// <summary>
            /// "ORM-D Class 9"
            /// </summary>
            ORM_D_Class_9,

            /// <summary>
            /// "Butane"
            /// </summary>
            Butane,

            /// <summary>
            /// "Fuel cell"
            /// </summary>
            Fuel_cell,

            /// <summary>
            /// "Gasoline"
            /// </summary>
            Gasoline,

            /// <summary>
            /// "Sealed Lead Acid Battery"
            /// </summary>
            Sealed_Lead_Acid_Battery
        }

        /// <summary>
        /// Merchant Rating
        /// </summary>
        public enum MerchantRating
        {
            RATING,
            RATING_COUNT
        }

        /// <summary>
        /// Offer Conditions
        /// </summary>
        public enum OfferCondition
        {
            UNKNOWN = 0,
            NEW = 1,
            USED_NEW = 2,
            USED_VERY_GOOD = 3,
            USED_GOOD = 4,
            USED_ACCEPTABLE = 5,
            REFURBISHED = 6,
            COLLECTIBLE_NEW = 7,
            COLLECTIBLE_VERY_GOOD = 8,
            COLLECTIBLE_GOOD = 9,
            COLLECTIBLE_ACCEPTABLE = 10
        }

        /// <summary>
        /// Product Type
        /// </summary>
        public enum ProductType
        {
            /// <summary>
            /// standard product - everything accessible
            /// </summary>
            STANDARD,

            /// <summary>
            /// downloadable product – no marketplace price data
            /// </summary>
            DOWNLOADABLE,

            /// <summary>
            /// ebook – no price data and sales rank accessible
            /// </summary>
            EBOOK,

            /// <summary>
            /// no data accessible (hidden prices due to MAP - minimum advertised price)
            /// </summary>
            UNACCESSIBLE,

            /// <summary>
            /// no data available due to invalid or deprecated asin, or other issues
            /// </summary>
            INVALID,

            /// <summary>
            /// Product is a parent ASIN. No product data accessible, variationCSV is set
            /// </summary>
            VARIATION_PARENT
        }

        /// <summary>
        /// Promotion Type
        /// </summary>
        public enum PromotionType
        {
            BuyAmountXGetAmountOffX,
            BuyAmountXGetPercentOffX,
            BuyAmountXGetSimpleShippingFreeX,
            BuyQuantityXGetAmountOffX,
            BuyQuantityXGetPercentOffX,
            BuyQuantityXGetQuantityFreeX,
            ForEachQuantityXGetAmountOffX,
            DiscountCheapestNofM,
            BuyQuantityXGetQuantityFreeGiftCard,
            BuyQuantityXGetSimpleShippingFreeX
        }

        /// <summary>
        /// Enum indicating locale
        /// </summary>
        public enum AmazonLocale
        {
            RESERVED,
            US,
            GB,
            DE,
            FR,
            JP,
            CA,
            CN,
            IT,
            ES,
            IN,
            MX,
            BR,
            AU
        }

        /// <summary>
        /// Enum that indicates the Response status
        /// </summary>
        public enum ResponseStatus
        {
            PENDING, OK, FAIL, NOT_ENOUGH_TOKEN, REQUEST_REJECTED, PAYMENT_REQUIRED, METHOD_NOT_ALLOWED, INTERNAL_SERVER_ERROR
        }
    }
}
