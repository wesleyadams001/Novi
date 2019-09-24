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
        /// Enumeration that represents the request types
        /// </summary>
        public enum ApiSpecificRequestTypes
        {
            KEEPA_DEFAULT,
            KEEPA_DEALS_REQUEST,
            KEEPA_PRODUCT_FINDER,
            KEEPA_TRACKING_ADD,
            KEEPA_TRACKING_BATCH_ADD,
            KEEPA_TRACKING_GET,
            KEEPA_TRACKING_LIST,
            KEEPA_TRACKING_NOTIFICATION,
            KEEPA_TRACKING_REMOVE,
            KEEPA_TRACKING_REMOVE_ALL,
            KEEPA_TRACKING_WEB_HOOK,
            KEEPA_BEST_SELLERS,
            KEEPA_CATEGORY_LOOKUP,
            KEEPA_CATEGORY_SEARCH,
            KEEPA_SELLER,
            KEEPA_TOP_SELLER,
            KEEPA_PRODUCT_SEARCH,
            KEEPA_PRODUCT,
            KEEPA_PRODUCT_BY_CODE
        }
    }
}
