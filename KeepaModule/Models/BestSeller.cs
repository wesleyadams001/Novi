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
    /// A best sellers ASIN list of a specific category.
    /// <p>
    /// Returned by:
    /// Request Best Sellers
    /// </summary>
    public class BestSellers
    {

        /// <summary>
        /// Integer value for the Amazon locale this category belongs to.
        /// {@link AmazonLocale}
        /// </summary>
        public byte domainId;

        /// <summary>
        /// States the last time we have updated the list, in Keepa Time minutes.<br>
        /// Use {@link KeepaTime#keepaMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        /// </summary>
        public int lastUpdate;

        /// <summary>
        /// The category node id used by Amazon. Represents the identifier of the category. Also part of the Product object's categories and rootCategory fields. Always a positive Long value or 0 if a product group was used.
        /// </summary>
        public long categoryId;

        /// <summary>
        /// An ASIN list. The list starts with the best selling product (lowest sales rank).
        /// </summary>
        public string[] asinList;

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
