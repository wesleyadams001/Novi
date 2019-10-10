using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepaModule.Models
{
    /// <summary>
    /// About:
    /// The seller object provides information about a Amazon marketplace seller.
    /// Returned by:
    /// The seller object is returned by the following request:
    /// Request Seller Information
    /// </summary>
    public class Seller
    {

        /// <summary>
        /// States the time we have started tracking this seller, in Keepa Time minutes.
        /// <p>Use {@link KeepaTime#keepaMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).</p>
        /// </summary>
        public int trackedSince; // keepa minutes

        /// <summary>
        /// The domainId of the products Amazon locale
        /// {@link AmazonLocale}
        /// </summary>
        public byte domainId;

        /// <summary>
        /// The seller id of the merchant.
        /// <p>
        /// Example: A2L77EE7U53NWQ (Amazon.com Warehouse Deals)
        /// </summary>
        public string sellerId;

        /// <summary>
        /// The name of seller.
        /// <p>
        /// Example: Amazon Warehouse Deals
        /// </summary>
        public string sellerName;

        /// <summary>
        /// Two dimensional history array that contains history data for this seller. First dimension index:
        /// <p>{@link MerchantCsvType}</p>
        /// 0 - RATING: The merchant's rating in percent, Integer from 0 to 100.
        /// 1 - RATING_COUNT: The merchant's total rating count, Integer.
        /// </summary>
        public int[][] csv;

        /// <summary>
        /// States the time of our last update of this seller, in Keepa Time minutes.
        /// <br>Example: 2711319
        /// </summary>
        public int lastUpdate; // keepa minutes

        /// <summary>
        /// Indicating whether or not our system identified that this seller attempts to scam users.
        /// </summary>
        public bool? isScammer;


        /// <summary>
        /// Boolean value indicating whether or not the seller currently has FBA listings.<br>
        /// This value is usually correct, but could be set to false even if the seller has FBA listings, since we are not always aware of all<br>
        /// seller listings. This can especially be the case with sellers with only a few listings consisting of slow-selling products.
        /// </summary>
        public bool? hasFBA;


        /// <summary>
        /// Contains the number of storefront ASINs if available and the last update of that metric.<br>
        /// Is null if not available (no storefront was ever retrieved). This field is available in the <br>
        /// default Request Seller Information (storefront parameter is not required).<br>
        /// <p>Use {@link KeepaTime#keepaMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).</p><br>
        /// Has the format: [ last update of the storefront in Keepa Time minutes, the count of storefront ASINs ]<br><br>
        /// Example: [2711319, 1200]
        /// </summary>
        public int[] totalStorefrontAsins = null;

        /// <summary>
        /// Only available if the <i>storefront</i> parameter was used and only updated if the <i>update</i> parameter was utilized.<br><br>
        /// String array containing up to 100,000 storefront ASINs, sorted by freshest first. The corresponding <br>
        /// time stamps can be found in the <i>asinListLastSeen</i> field.<br>
        /// Example: ["B00M0QVG3W", "B00M4KCH2A"]
        /// </summary>
        public string[] asinList;

        /// <summary>
        ///  Only available if the <i>storefront</i> parameter was used and only updated if the <i>update</i> parameter was utilized.<br><br>
        ///  Contains the last time (in Keepa Time minutes) we were able to verify each ASIN in the _asinList_ field.<br>
        ///  <i>asinList</i> and <i>asinListLastSeen</i> share the same indexation, so the corresponding time stamp<br>
        ///  for `asinList[10]` would be `asinListLastSeen[10]`.
        ///  <p>Use {@link KeepaTime#keepaMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).</p>
        ///  <br>
        ///  Example: [2711319, 2711311]
        /// </summary>
        public int[] asinListLastSeen;

        /// <summary>
        /// 	Only available if the <i>storefront</i> parameter was used and only updated if the <i>update</i> parameter was utilized.<br><br>
        ///  Contains the total amount of listings of this seller. Includes historical data<br>
        ///  <i>asinList</i> and <i>asinListLastSeen</i> share the same indexation, so the corresponding time stamp<br>
        ///  for `asinList[10]` would be `asinListLastSeen[10]`. Has the format: Keepa Time minutes, count, ...
        ///  <p>Use {@link KeepaTime#keepaMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).</p>
        ///  <br>
        ///  Example: [2711319, 1200, 2711719, 1187]
        /// </summary>
        public int[] totalStorefrontAsinsCSV;

        public class MerchantCsvType
        {
            /// <summary>
            /// enum to represent the type
            /// </summary>
            private enum Type
            {
                RATING,
                RATING_COUNT
            }

            private static Dictionary<int, bool?> values = new Dictionary<int, bool?>();

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="i"></param>
            /// <param name="price"></param>
		    MerchantCsvType(int i, bool? price)
            {
                int index = i;
                bool? isPrice = price;

                //values.Add()

            }

            /// <summary>
            /// Retrieve the CSV type from the index
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            //public static MerchantCsvType getCSVTypeFromIndex(int index)
            //{
            //    foreach (MerchantCsvType type in MerchantCsvType.values)
            //    {
            //        if (type.index == index) return type;
            //    }
            //    return RATING;
            //}
        }


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
