using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Tools;

namespace NtfsModule.Models
{
    /// <summary>
    /// The Ntfs Product Class
    /// </summary>
    public class Product
    {

        /// <summary>
        /// The ASIN of the product
        /// </summary>
        public string asin = null;

        /// <summary>
        /// The domainId of the products Amazon locale <br>
        /// {@link AmazonLocale}
        /// </summary>
        public byte domainId = 0;

        /// <summary>
        /// The ASIN of the parent product (if asin has variations, otherwise null)
        /// </summary>
        public string parentAsin = null;

        /// <summary>
        /// Comma separated list of variation ASINs of the product (if asin is parentAsin, otherwise null)
        /// </summary>
        public string variationCSV = null;

        /// <summary>
        /// The UPC of the product. Caution: leading zeros are truncated.
        /// @deprecated use first upcList entry instead.
        /// </summary>
        public long upc = 0;

        /// <summary>
        /// The EAN of the product. Caution: leading zeros are truncated.
        /// @deprecated use first eanList entry instead.
        /// </summary>
        public long ean = 0;

        /// <summary>
        /// A list of UPC assigned to this product. The first index is the primary UPC. null if not available.
        /// </summary>
        public String[] upcList = null;

        /// <summary>
        /// A list of EAN assigned to this product. The first index is the primary EAN. null if not available.
        /// </summary>
        public String[] eanList = null;

        /// <summary>
        /// The manufacturer’s part number.
        /// </summary>
        public string mpn = null;

        /// <summary>
        /// Comma separated list of image names of the product. Full Amazon image path:<br>
        /// https://images-na.ssl-images-amazon.com/images/I/_image name_
        /// </summary>
        public string imagesCSV = null;

        /// <summary>
        /// Array of category node ids
        /// </summary>
        public long[] categories = null;

        /// <summary>
        /// Category node id of the products' root category. 0 if no root category known
        /// </summary>
        public long rootCategory = 0L;

        /// <summary>
        /// Name of the manufacturer
        /// </summary>
        public string manufacturer = null;

        /// <summary>
        /// Title of the product. Caution: may contain HTML markup in rare cases.
        /// </summary>
        public string title = null;

        /// <summary>
        /// States the time we have started tracking this product, in Ntfs Time minutes.<br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        /// </summary>
        public int trackingSince = 0;

        /// <summary>
        /// States the time the item was first listed on Amazon, in Ntfs Time minutes.<br>
        /// It is updated in conjunction with the offers request, but always accessible.<br>
        /// This timestamp is only available for some products. If not available the field has the value 0.
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        /// </summary>
        public int listedSince = 0;

        /// <summary>
        /// An item's brand. null if not available.
        /// </summary>
        public string brand = null;

        /// <summary>
        /// The item's label. null if not available.
        /// </summary>
        public string label = null;

        /// <summary>
        /// The item's department. null if not available.
        /// </summary>
        public string department = null;

        /// <summary>
        /// The item's publisher. null if not available.
        /// </summary>
        public string publisher = null;

        /// <summary>
        /// The item's productGroup. null if not available.
        /// </summary>
        public string productGroup = null;

        /// <summary>
        /// The item's partNumber. null if not available.
        /// </summary>
        public string partNumber = null;

        /// <summary>
        /// The item's studio. null if not available.
        /// </summary>
        public string studio = null;

        /// <summary>
        /// The item's genre. null if not available.
        /// </summary>
        public string genre = null;

        /// <summary>
        /// The item's model. null if not available.
        /// </summary>
        public string model = null;

        /// <summary>
        /// The item's color. null if not available.
        /// </summary>
        public string color = null;

        /// <summary>
        /// The item's size. null if not available.
        /// </summary>
        public string size = null;

        /// <summary>
        /// The item's edition. null if not available.
        /// </summary>
        public string edition = null;

        /// <summary>
        /// The item's platform. null if not available.
        /// </summary>
        public string platform = null;

        /// <summary>
        /// The item's format. null if not available.
        /// </summary>
        public string format = null;

        /// <summary>
        /// The item’s author. null if not available.
        /// </summary>
        public string author = null;

        /// <summary>
        /// The item’s binding. null if not available. If the item is not a book it is usually the product category instead.
        /// </summary>
        public string binding = null;

        /// <summary>
        /// Represents the category tree as an ordered array of CategoryTreeEntry objects.
        /// </summary>
        public CategoryTreeEntry[] categoryTree = null;

        /// <summary>
        /// The number of items of this product. -1 if not available.
        /// </summary>
        public int numberOfItems = -1;

        /// <summary>
        /// The number of pages of this product. -1 if not available.
        /// </summary>
        public int numberOfPages = -1;

        /// <summary>
        /// The item’s publication date in one of the following three formats:<br>
        /// YYYY or YYYYMM or YYYYMMDD (Y= year, M = month, D = day)<br>
        /// -1 if not available.<br><br>
        /// Examples:<br>
        /// 1978 = the year 1978<br>
        /// 200301 = January 2003<br>
        /// 20150409 = April 9th, 2015
        /// </summary>
        public int publicationDate = -1;

        /// <summary>
        /// The item’s release date in one of the following three formats:<br>
        /// YYYY or YYYYMM or YYYYMMDD (Y= year, M = month, D = day)<br>
        /// -1 if not available.<br><br>
        /// Examples:<br>
        /// 1978 = the year 1978<br>
        /// 200301 = January 2003<br>
        /// 20150409 = April 9th, 2015
        /// </summary>
        public int releaseDate = -1;

        /// <summary>
        /// An item can have one or more languages. Each language entry has a name and a type.
        /// Some also have an audio format. null if not available.<br><br>
        /// Examples:<br>
        /// [ [ “English”, “Published” ], [ “English”, “Original Language” ] ]<br>
        /// With audio format:<br>
        /// [ [ “Englisch”, “Originalsprache”, “DTS-HD 2.0” ], [ “Deutsch”, null, “DTS-HD 2.0” ] ]
        /// </summary>
        public String[][] languages = null;

        /// <summary>
        /// A list of the product features / bullet points. null if not available. <br>
        /// An entry can contain HTML markup in rare cases. We currently limit each entry to a maximum of 1000 characters<br>
        /// (if the feature is longer it will be cut off). This limitation may change in the future without prior notice.
        /// </summary>
        public String[] features = null;

        /// <summary>
        /// A description of the product. null if not available. Most description contain HTML markup.<br>
        /// We limit the product description to a maximum of 2000 characters (if the description is<br>
        /// longer it will be cut off). This limitation may change in the future without prior notice.
        /// </summary>
        public string description = null;

        /// <summary>
        /// The item's format. null if not available.
        /// </summary>
        public HazardousMaterialType hazardousMaterialType = null;

        /// <summary>
        /// The package's height in millimeter. 0 or -1 if not available.
        /// </summary>
        public int packageHeight = -1;

        /// <summary>
        /// The package's length in millimeter. 0 or -1 if not available.
        /// </summary>
        public int packageLength = -1;

        /// <summary>
        /// The package's width in millimeter. 0 or -1 if not available.
        /// </summary>
        public int packageWidth = -1;

        /// <summary>
        /// The package's weight in gram. 0 or -1 if not available.
        /// </summary>
        public int packageWeight = -1;

        /// <summary>
        /// Quantity of items in a package. 0 or -1 if not available.
        /// </summary>
        public int packageQuantity = -1;

        /// <summary>
        /// Contains the lowest priced matching eBay listing Ids.
        /// Always contains two entries, the first one is the listing id of the lowest priced listing in new condition,
        /// the second in used condition. null or 0 if not available.<br>
        /// Example: [ 273344490183, 0 ]
        /// </summary>
        public long[] ebayListingIds = null;

        /// <summary>
        /// Indicates if the item is considered to be for adults only.
        /// </summary>
        public bool isAdultProduct = false;

        /// <summary>
        /// Whether or not the product is eligible for trade-in.
        /// </summary>
        public bool isEligibleForTradeIn = false;

        /// <summary>
        /// Whether or not the product is eligible for super saver shipping by Amazon (not FBA).
        /// </summary>
        public bool isEligibleForSuperSaverShipping = false;

        /// <summary>
        /// States the last time we have updated the information for this product, in Ntfs Time minutes.<br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        /// </summary>
        public int lastUpdate = 0;

        /// <summary>
        /// States the last time we have registered a price change (any price kind), in Ntfs Time minutes.<br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} to get an uncompressed timestamp (Unix epoch time).
        /// </summary>
        public int lastPriceChange = 0;

        /// <summary>
        /// States the last time we have updated the eBay prices for this product, in Ntfs Time minutes.<br>
        /// If no matching products were found the integer is negative.<br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        /// </summary>
        public int lastEbayUpdate = 0;

        /// <summary>
        /// States the last time we have updated the product rating and review count, in Ntfs Time minutes.<br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        /// </summary>
        public int lastRatingUpdate = 0;

        /// <summary>
        /// Ntfs product type {@link Product.ProductType}. Must always be evaluated first.
        /// </summary>
        public byte productType = 0;

        /// <summary>
        /// Whether or not the product has reviews.
        /// </summary>
        public bool hasReviews = false;

        /// <summary>
        /// Optional field. Only set if the <i>stats</i> parameter was used in the Product Request. Contains statistic values.
        /// </summary>
        public Stats stats = null;

        /// <summary>
        /// Optional field. Only set if the <i>offers</i> parameter was used in the Product Request.
        /// </summary>
        public Offer[] offers = null;

        /// <summary>
        /// Optional field. Only set if the offers parameter was used in the Product Request.<br>
        /// Contains an ordered array of index positions in the offers array for all Marketplace Offer Objects114 retrieved for this call.<br>
        /// The sequence of integers reflects the ordering of the offers on the Amazon offer page (for all conditions).<br>
        /// Since the offers field contains historical offers as well as current offers, one can use this array to <br>
        /// look up all offers that are currently listed on Amazon in the correct order. <br><br>
        /// Example:<br> [ 3, 5, 2, 18, 15 ] - The offer with the array index 3 of the offers field is currently the first <br>
        ///     one listed on the offer listings page on Amazon, followed by the offer with the index 5, and so on.<br><br>
        /// Example with duplicates:<br> [ 3, 5, 2, 18, 5 ] - The second offer, as listed on Amazon, is a lower priced duplicate <br>
        ///     of the 6th offer on Amazon. The lower priced one is included in the offers field at index 5.
        /// </summary>
        public int[] liveOffersOrder = null;

        /// <summary>
        /// Optional field. Only set if the offers parameter was used in the Product Request.<br>
        /// Contains a history of sellerIds that held the Buy Box in the format Ntfs time minutes, sellerId, [...].<br>
        /// If no seller qualified for the Buy Box the sellerId "-1" is used. If it was hold by an unknown seller (a brand new one) the sellerId is "-2".<br>
        /// Example: ["2860926","ATVPDKIKX0DER", …]
        /// <p>Use {@link NtfsTime#NtfsMinuteToUnixInMillis(String)} (long)} to get an uncompressed timestamp (Unix epoch time).</p>
        /// </summary>
        public String[] buyBoxSellerIdHistory = null;

        /// <summary>
        /// Only valid if the offers parameter was used in the Product Request.
        /// Boolean indicating if the ASIN will be redirected to another one on Amazon
        /// (example: the ASIN has the color black variation, which is not available any more
        /// and is redirected on Amazon to the color red).
        /// </summary>
        public bool isRedirectASIN = false;

        /// <summary>
        /// Only valid if the offers parameter was used in the Product Request. Boolean indicating if the product's Buy Box is available for subscribe and save.
        /// </summary>
        public bool isSNS = false;

        /// <summary>
        /// Only valid if the offers parameter was used in the Product Request. Boolean indicating if the system was able to retrieve fresh offer information.
        /// </summary>
        public bool offersSuccessful = false;

        /// <summary>
        /// One or two “Frequently Bought Together” ASINs. null if not available. Field is updated when the offers parameter was used.
        /// </summary>
        public String[] frequentlyBoughtTogether = null;

        /// <summary>
        /// Contains current promotions for this product. Only Amazon US promotions by Amazon (not 3rd party) are collected. In rare cases data can be incomplete.
        /// </summary>
        public PromotionObject[] promotions = null;

        /// <summary>
        /// Contains the dimension attributes for up to 50 variations of this product. Only available on parent ASINs.
        /// </summary>
        public VariationObject[] variations = null;

        /// <summary>
        /// Availability of the Amazon offer {@link Product.AvailabilityType}.
        /// </summary>
        public int availabilityAmazon = -1;

        /// <summary>
        /// Contains coupon details if any are available for the product. null if not available.
        /// Integer array with always two entries: The first entry is the discount of a one time coupon, the second is a subscribe and save coupon.
        /// Entry value is either 0 if no coupon of that type is offered, positive for an absolute discount or negative for a percentage discount.
        /// The coupons field is always accessible, but only updated if the offers parameter was used in the Product Request.
        /// <p>Example:<br>
        /// 		[ 200, -15 ] - Both coupon types available: $2 one time discount or 15% for subscribe and save.<br>
        ///      [ -7, 0 ] - Only one time coupon type is available offering a 7% discount.
        /// </p>
        /// </summary>
        public int[] coupon = null;

        /// <summary>
        /// Whether or not the current new price is MAP restricted. Can be used to differentiate out of stock vs. MAP restricted prices (as in both cases the current price is -1).
        /// </summary>
        public bool newPriceIsMAP = false;

        /// <summary>
        /// FBA fees for this product. If FBA fee information has not yet been collected for this product the field will be null.
        /// </summary>
        public FBAFeesObject fbaFees = null;

        /// <summary>
        /// Integer[][] - two dimensional price history array.<br>
        /// First dimension: {@link Product.CsvType}<br>
        /// Second dimension:<br>
        /// Each array has the format timestamp, price, […]. To get an uncompressed timestamp use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)}.<br>
        /// Example: "csv[0]": [411180,4900, ... ]<br>
        /// timestamp: 411180 => 1318510800000<br>
        /// price: 4900 => $ 49.00 (if domainId is 5, Japan, then price: 4900 => ¥ 4900)<br>
        /// A price of '-1' means that there was no offer at the given timestamp (e.g. out of stock).
        /// </summary>
        public int[][] csv = null;

        /// <summary>
        /// Amazon internal product type categorization.
        /// </summary>
        public string type = null;


        #region CsvType

        public class CsvType : EnumBaseType<CsvType>
        {
            #region Properties
            /// <summary>
            /// Amazon price history
            /// </summary>
            public static readonly CsvType AMAZON = new CsvType(0, "AMAZON", true, true, false, false);

            /// <summary>
            /// Marketplace/3rd party New price history - Amazon is considered to be part of the marketplace as well,
            /// so if Amazon has the overall lowest new (!) price, the marketplace new price in the corresponding time interval
            /// will be identical to the Amazon price (except if there is only one marketplace offer).
            /// Shipping and Handling costs not included!
            /// </summary>
            public static readonly CsvType NEW = new CsvType(1, "NEW", true, true, false, false);

            /// <summary>
            /// Marketplace/3rd party Used price history
            /// </summary>
            public static readonly CsvType USED = new CsvType(2, "USED", true, true, false, false);

            /// <summary>
            /// Sales Rank history. Not every product has a Sales Rank.
            /// </summary>
            public static readonly CsvType SALES = new CsvType(3, "SALES", false, true, false, false);

            /// <summary>
            /// List Price history
            /// </summary>
            public static readonly CsvType LIST_PRICE = new CsvType(4, "LIST_PRICE", true, false, false, false);

            /// <summary>
            /// Collectible Price history
            /// </summary>
            public static readonly CsvType COLLECTIBLE = new CsvType(5, "COLLECTIBLE", true, true, false, false);

            /// <summary>
            /// Refurbished Price history
            /// </summary>
            public static readonly CsvType REFURBISHED = new CsvType(6, "REFURBISHED", true, true, false, false);

            /// <summary>
            /// 3rd party (not including Amazon) New price history including shipping costs, only fulfilled by merchant (FBM).
            /// </summary>
            public static readonly CsvType NEW_FBM_SHIPPING = new CsvType(7, "NEW_FBM_SHIPPING", true, true, true, true);

            /// <summary>
            /// 3rd party (not including Amazon) New price history including shipping costs, only fulfilled by merchant (FBM).
            /// </summary>
            public static readonly CsvType LIGHTNING_DEAL = new CsvType(8, "LIGHTNING_DEAL", true, true, false, false);

            /// <summary>
            /// Amazon Warehouse Deals price history. Mostly of used condition, rarely new.
            /// </summary>
            public static readonly CsvType WAREHOUSE = new CsvType(9, "WAREHOUSE", true, true, false, true);

            /// <summary>
            /// Price history of the lowest 3rd party (not including Amazon/Warehouse) New offer that is fulfilled by Amazon
            /// </summary>
            public static readonly CsvType NEW_FBA = new CsvType(10, "NEW_FBA", true, true, false, true);

            /// <summary>
            /// New offer count history
            /// </summary>
            public static readonly CsvType COUNT_NEW = new CsvType(11, "COUNT_NEW", false, false, false, false);

            /// <summary>
            /// Used offer count history
            /// </summary>
            public static readonly CsvType COUNT_USED = new CsvType(12, "COUNT_USED", false, false, false, false);

            /// <summary>
            /// Refurbished offer count history
            /// </summary>
            public static readonly CsvType COUNT_REFURBISHED = new CsvType(13, "COUNT_REFURBISHED", false, false, false, false);

            /// <summary>
            /// Collectible offer count history
            /// </summary>
            public static readonly CsvType COUNT_COLLECTIBLE = new CsvType(14, "COUNT_COLLECTIBLE", false, false, false, false);

            /// <summary>
            /// History of past updates to all offers-parameter related data: offers, buyBoxSellerIdHistory, isSNS, isRedirectASIN and the csv types
            /// NEW_SHIPPING, WAREHOUSE, FBA, BUY_BOX_SHIPPING, USED_///_SHIPPING, COLLECTIBLE_///_SHIPPING and REFURBISHED_SHIPPING.
            /// As updates to those fields are infrequent it is important to know when our system updated them.
            /// The absolute value indicates the amount of offers fetched at the given time.
            /// If the value is positive it means all available offers were fetched. It's negative if there were more offers than fetched.
            /// </summary>
            public static readonly CsvType EXTRA_INFO_UPDATES = new CsvType(15, "EXTRA_INFO_UPDATES", false, false, false, true);

            /// <summary>
            /// The product's rating history. A rating is an integer from 0 to 50 (e.g. 45 = 4.5 stars)
            /// </summary>
            public static readonly CsvType RATING = new CsvType(16, "RATING", false, false, false, true);

            /// <summary>
            /// The product's review count history.
            /// </summary>
            public static readonly CsvType COUNT_REVIEWS = new CsvType(17, "COUNT_REVIEWS", false, false, false, true);

            /// <summary>
            /// The price history of the buy box. If no offer qualified for the buy box the price has the value -1. Including shipping costs.
            /// </summary>
            public static readonly CsvType BUY_BOX_SHIPPING = new CsvType(18, "BUY_BOX_SHIPPING", true, false, true, true);

            /// <summary>
            /// "Used - Like New" price history including shipping costs.
            /// </summary>
            public static readonly CsvType USED_NEW_SHIPPING = new CsvType(19, "USED_NEW_SHIPPING", true, true, true, true);

            /// <summary>
            /// "Used - Very Good" price history including shipping costs.
            /// </summary>
            public static readonly CsvType USED_VERY_GOOD_SHIPPING = new CsvType(20, "USED_VERY_GOOD_SHIPPING", true, true, true, true);

            /// <summary>
            /// "Used - Good" price history including shipping costs.
            /// </summary>
            public static readonly CsvType USED_GOOD_SHIPPING = new CsvType(21, "USED_GOOD_SHIPPING", true, true, true, true);

            /// <summary>
            /// "Used - Acceptable" price history including shipping costs.
            /// </summary>
            public static readonly CsvType USED_ACCEPTABLE_SHIPPING = new CsvType(22, "USED_ACCEPTABLE_SHIPPING", true, true, true, true);

            /// <summary>
            /// "Collectible - Like New" price history including shipping costs.
            /// </summary>
            public static readonly CsvType COLLECTIBLE_NEW_SHIPPING = new CsvType(23, "COLLECTIBLE_NEW_SHIPPING", true, true, true, true);

            /// <summary>
            /// "Collectible - Very Good" price history including shipping costs.
            /// </summary>
            public static readonly CsvType COLLECTIBLE_VERY_GOOD_SHIPPING = new CsvType(24, "COLLECTIBLE_VERY_GOOD_SHIPPING", true, true, true, true);

            /// <summary>
            /// "Collectible - Good" price history including shipping costs.
            /// </summary>
            public static readonly CsvType COLLECTIBLE_GOOD_SHIPPING = new CsvType(25, "COLLECTIBLE_GOOD_SHIPPING", true, true, true, true);

            /// <summary>
            /// "Collectible - Acceptable" price history including shipping costs.
            /// </summary>
            public static readonly CsvType COLLECTIBLE_ACCEPTABLE_SHIPPING = new CsvType(26, "COLLECTIBLE_ACCEPTABLE_SHIPPING", true, true, true, true);

            /// <summary>
            /// Refurbished price history including shipping costs.
            /// </summary>
            public static readonly CsvType REFURBISHED_SHIPPING = new CsvType(27, "REFURBISHED_SHIPPING", true, true, true, true);

            /// <summary>
            /// price history of the lowest new price on the respective eBay locale, including shipping costs.
            /// </summary>
            public static readonly CsvType EBAY_NEW_SHIPPING = new CsvType(28, "EBAY_NEW_SHIPPING", true, false, true, false);

            /// <summary>
            /// price history of the lowest used price on the respective eBay locale, including shipping costs.
            /// </summary>
            public static readonly CsvType EBAY_USED_SHIPPING = new CsvType(29, "EBAY_USED_SHIPPING", true, false, true, false);

            /// <summary>
            /// The trade in price history. Amazon trade-in is not available for every locale.
            /// </summary>
            public static readonly CsvType TRADE_IN = new CsvType(30, "TRADE_IN", true, false, false, false);

            /// <summary>
            /// Rental price history. Requires use of the rental and offers parameter. Amazon Rental is only available for Amazon US.
            /// </summary>
            public static readonly CsvType RENT = new CsvType(31, "RENT", true, false, false, true);
            #endregion

            /// <summary>
            /// Index
            /// </summary>
            public int index;

            /// <summary>
            /// String Name
            /// </summary>
            public string enumString;

            /// <summary>
            /// If the values are prices.
            /// </summary>
            public bool isPrice;

            /// <summary>
            /// If the CSV contains shipping costs
            /// If true, csv format has 3 entries: time, price, shippingCosts
            /// </summary>
            public bool isWithShipping;

            /// <summary>
            /// If the type can be used to request deals.
            /// </summary>
            public bool isDealRelevant;

            /// <summary>
            /// True if the data is only accessible in conjunction with the 'offers' parameter of the product request.
            /// </summary>
            public bool isExtraData;


            CsvType(int key, string val, bool price, bool deal, bool shipping, bool extra) : base(key, val)
            {
                index = key;
                enumString = val;
                isPrice = price;
                isDealRelevant = deal;
                isExtraData = extra;
                isWithShipping = shipping;

            }
            #region Methods
            public static ReadOnlyCollection<CsvType> GetValues()
            {
                return GetBaseValues();
            }

            public static CsvType GetByKey(int key)
            {
                return GetBaseByKey(key);
            }
            #endregion
        }


        #endregion

        #region AvailabilityType

        public class AvailabilityType : EnumBaseType<AvailabilityType>
        {
            #region Properties

            /// <summary>
            /// No Amazon offer exists
            /// </summary>
            public static readonly AvailabilityType NO_OFFER = new AvailabilityType(-1, "NO_OFFER");

            /// <summary>
            /// Amazon offer is in stock and shippable
            /// </summary>
            public static readonly AvailabilityType NOW = new AvailabilityType(0, "NOW");

            /// <summary>
            /// Amazon offer is currently not in stock but will be in the future (i.e. back-ordered, pre-order)
            /// </summary>
            public static readonly AvailabilityType FUTURE = new AvailabilityType(1, "FUTURE");

            /// <summary>
            /// Amazon offer availability is "unknown"
            /// </summary>
            public static readonly AvailabilityType UNKNOWN = new AvailabilityType(2, "UNKNOWN");

            /// <summary>
            /// Unrecognized Amazon availability status
            /// </summary>
            public static readonly AvailabilityType OTHER = new AvailabilityType(3, "OTHER");
            #endregion

            /// <summary>
            /// Index
            /// </summary>
            public int index;

            /// <summary>
            /// Associate enum value
            /// </summary>
            public string value;

            AvailabilityType(int key, string val) : base(key, val)
            {
                index = key;
                value = val;

            }

            #region Methods
            public static ReadOnlyCollection<AvailabilityType> GetValues()
            {
                return GetBaseValues();
            }

            public static AvailabilityType GetByKey(int key)
            {
                return GetBaseByKey(key);
            }
            #endregion
        }
        #endregion

        #region ProductType

        public class ProductType : EnumBaseType<ProductType>
        {
            #region Properties

            /// <summary>
            /// standard product - everything accessible
            /// </summary>
            public static readonly ProductType STANDARD = new ProductType(0, "STANDARD");

            /// <summary>
            /// downloadable product – no marketplace price data
            /// </summary>
            public static readonly ProductType DOWNLOADABLE = new ProductType(1, "DOWNLOADABLE");

            /// <summary>
            /// ebook – no price data and sales rank accessible
            /// </summary>
            public static readonly ProductType EBOOK = new ProductType(2, "EBOOK");

            /// <summary>
            /// no data accessible (hidden prices due to MAP - minimum advertised price)
            /// </summary>
            public static readonly ProductType UNACCESSIBLE = new ProductType(3, "UNACCESSIBLE");

            /// <summary>
            /// no data available due to invalid or deprecated asin, or other issues
            /// </summary>
            public static readonly ProductType INVALID = new ProductType(4, "INVALID");

            /// <summary>
            /// Product is a parent ASIN. No product data accessible, variationCSV is set
            /// </summary>
            public static readonly ProductType VARIATION_PARENT = new ProductType(4, "INVALID");
            #endregion

            /// <summary>
            /// Index
            /// </summary>
            public int index;

            /// <summary>
            /// Associate enum value
            /// </summary>
            public string value;

            ProductType(int key, string val) : base(key, val)
            {
                index = key;
                value = val;

            }

            #region Methods
            public static ReadOnlyCollection<ProductType> GetValues()
            {
                return GetBaseValues();
            }

            public static ProductType GetByKey(int key)
            {
                return GetBaseByKey(key);
            }

            /// <summary>
            /// Override of the To string method
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
            #endregion
        }
        #endregion

        /// <summary>
        /// Category Tree Entries object
        /// </summary>
        public class CategoryTreeEntry
        {
            /// <summary>
            /// Category ID
            /// </summary>
            public long catId;

            /// <summary>
            /// Name of Category
            /// </summary>
            public string name;
        }

        #region HazardousMaterialType

        public class HazardousMaterialType : EnumBaseType<HazardousMaterialType>
        {
            #region Properties

            /// <summary>
            /// "ORM-D Class"
            /// </summary>
            public static readonly HazardousMaterialType ORM_D_Class = new HazardousMaterialType(0, "ORM_D_Class");

            /// <summary>
            /// "ORM-D Class 1"
            /// </summary>
            public static readonly HazardousMaterialType ORM_D_Class_1 = new HazardousMaterialType(1, "ORM_D_Class_1");

            /// <summary>
            /// "ORM-D Class 2"
            /// </summary>
            public static readonly HazardousMaterialType ORM_D_Class_2 = new HazardousMaterialType(2, "ORM_D_Class_2");

            /// <summary>
            /// "ORM-D Class 3"
            /// </summary>
            public static readonly HazardousMaterialType ORM_D_Class_3 = new HazardousMaterialType(3, "ORM_D_Class_3");

            /// <summary>
            /// "ORM-D Class 4"
            /// </summary>
            public static readonly HazardousMaterialType ORM_D_Class_4 = new HazardousMaterialType(4, "ORM_D_Class_4");

            /// <summary>
            /// "ORM-D Class 5"
            /// </summary>
            public static readonly HazardousMaterialType ORM_D_Class_5 = new HazardousMaterialType(5, "ORM_D_Class_5");

            /// <summary>
            /// "ORM-D Class 6"
            /// </summary>
            public static readonly HazardousMaterialType ORM_D_Class_6 = new HazardousMaterialType(6, "ORM_D_Class_6");

            /// <summary>
            /// "ORM-D Class 7"
            /// </summary>
            public static readonly HazardousMaterialType ORM_D_Class_7 = new HazardousMaterialType(7, "ORM_D_Class_7");

            /// <summary>
            /// "ORM-D Class 8"
            /// </summary>
            public static readonly HazardousMaterialType ORM_D_Class_8 = new HazardousMaterialType(8, "ORM_D_Class_8");

            /// <summary>
            /// "ORM-D Class 9"
            /// </summary>
            public static readonly HazardousMaterialType ORM_D_Class_9 = new HazardousMaterialType(9, "ORM_D_Class_9");

            /// <summary>
            /// "Butane"
            /// </summary>
            public static readonly HazardousMaterialType Butane = new HazardousMaterialType(10, "Butane");

            /// <summary>
            /// "Fuel cell"
            /// </summary>
            public static readonly HazardousMaterialType Fuel_cell = new HazardousMaterialType(11, "Fuel_cell");

            /// <summary>
            /// "Gasoline"
            /// </summary>
            public static readonly HazardousMaterialType Gasoline = new HazardousMaterialType(12, "Gasoline");

            /// <summary>
            /// "Sealed Lead Acid Battery"
            /// </summary>
            public static readonly HazardousMaterialType Sealed_Lead_Acid_Battery = new HazardousMaterialType(13, "Sealed_Lead_Acid_Battery");
            #endregion

            /// <summary>
            /// Index
            /// </summary>
            public int index;

            /// <summary>
            /// Associate enum value
            /// </summary>
            public string value;

            HazardousMaterialType(int key, string val) : base(key, val)
            {
                index = key;
                value = val;

            }

            #region Methods
            public static ReadOnlyCollection<HazardousMaterialType> GetValues()
            {
                return GetBaseValues();
            }

            public static HazardousMaterialType GetByKey(int key)
            {
                return GetBaseByKey(key);
            }

            #endregion
        }
        #endregion


        public class PromotionObject
        {
            /// <summary>
            /// The type of promotion
            /// </summary>
            public PromotionType type = null;

            public string eligibilityRequirementDescription = null;

            public string benefitDescription = null;

            /// <summary>
            /// unique Id of this promotion.
            /// </summary>
            public string promotionId = null;
        }

        public class VariationObject
        {
            /// <summary>
            /// Variation ASIN
            /// </summary>
            public string asin = null;

            /// <summary>
            /// This variation ASIN's dimension attributes
            /// </summary>
            public VariationAttributeObject[] attributes = null;
        }

        public class VariationAttributeObject
        {
            /// <summary>
            /// dimension type, e.g. Color
            /// </summary>
            public string dimension = null;

            /// <summary>
            /// dimension value, e.g. Red
            /// </summary>
            public string value = null;
        }

        /// <summary>
        /// Contains detailed FBA fees. If the total fee is 0 the product does not have (valid) dimensions and thus the fee can not be calculated.
        /// </summary>
        public class FBAFeesObject
        {
            public int storageFee;
            public int storageFeeTax;
            public int pickAndPackFee;
            public int pickAndPackFeeTax;
        }

        #region PromotionType

        public class PromotionType : EnumBaseType<PromotionType>
        {
            #region Properties

            public static readonly PromotionType BuyAmountXGetAmountOffX = new PromotionType(0, "BuyAmountXGetAmountOffX");
            public static readonly PromotionType BuyAmountXGetPercentOffX = new PromotionType(1, "BuyAmountXGetPercentOffX");
            public static readonly PromotionType BuyAmountXGetSimpleShippingFreeX = new PromotionType(2, "BuyAmountXGetSimpleShippingFreeX");
            public static readonly PromotionType BuyQuantityXGetAmountOffX = new PromotionType(3, "BuyQuantityXGetAmountOffX");
            public static readonly PromotionType BuyQuantityXGetPercentOffX = new PromotionType(4, "BuyQuantityXGetPercentOffX");
            public static readonly PromotionType BuyQuantityXGetQuantityFreeX = new PromotionType(5, "BuyQuantityXGetQuantityFreeX");
            public static readonly PromotionType ForEachQuantityXGetAmountOffX = new PromotionType(6, "ForEachQuantityXGetAmountOffX");
            public static readonly PromotionType DiscountCheapestNofM = new PromotionType(7, "DiscountCheapestNofM");
            public static readonly PromotionType BuyQuantityXGetQuantityFreeGiftCard = new PromotionType(8, "BuyQuantityXGetQuantityFreeGiftCard");
            public static readonly PromotionType BuyQuantityXGetSimpleShippingFreeX = new PromotionType(9, "BuyQuantityXGetSimpleShippingFreeX");
            #endregion

            /// <summary>
            /// Index
            /// </summary>
            public int index;

            /// <summary>
            /// Associate enum value
            /// </summary>
            public string value;

            PromotionType(int key, string val) : base(key, val)
            {
                index = key;
                value = val;

            }

            #region Methods
            public static ReadOnlyCollection<PromotionType> GetValues()
            {
                return GetBaseValues();
            }

            public static PromotionType GetByKey(int key)
            {
                return GetBaseByKey(key);
            }

            #endregion
        }
        #endregion

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
