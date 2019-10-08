using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            [Description("KEEPA_DEFAULT")]
            KEEPA_DEFAULT,
            [Description("KEEPA_DEALS_REQUEST")]
            KEEPA_DEALS_REQUEST,
            [Description("KEEPA_PRODUCT_FINDER")]
            KEEPA_PRODUCT_FINDER,
            [Description("KEEPA_TRACKING_ADD")]
            KEEPA_TRACKING_ADD,
            [Description("KEEPA_TRACKING_BATCH_ADD")]
            KEEPA_TRACKING_BATCH_ADD,
            [Description("KEEPA_TRACKING_GET")]
            KEEPA_TRACKING_GET,
            [Description("KEEPA_TRACKING_LIST")]
            KEEPA_TRACKING_LIST,
            [Description("KEEPA_TRACKING_NOTIFICATION")]
            KEEPA_TRACKING_NOTIFICATION,
            [Description("KEEPA_TRACKING_REMOVE")]
            KEEPA_TRACKING_REMOVE,
            [Description("KEEPA_TRACKING_REMOVE_ALL")]
            KEEPA_TRACKING_REMOVE_ALL,
            [Description("KEEPA_TRACKING_WEB_HOOK")]
            KEEPA_TRACKING_WEB_HOOK,
            [Description("KEEPA_BEST_SELLERS")]
            KEEPA_BEST_SELLERS,
            [Description("KEEPA_CATEGORY_LOOKUP")]
            KEEPA_CATEGORY_LOOKUP,
            [Description("KEEPA_CATEGORY_SEARCH")]
            KEEPA_CATEGORY_SEARCH,
            [Description("KEEPA_SELLER")]
            KEEPA_SELLER,
            [Description("KEEPA_TOP_SELLER")]
            KEEPA_TOP_SELLER,
            [Description("KEEPA_PRODUCT_SEARCH")]
            KEEPA_PRODUCT_SEARCH,
            [Description("KEEPA_PRODUCT")]
            KEEPA_PRODUCT,
            [Description("KEEPA_PRODUCT_BY_CODE")]
            KEEPA_PRODUCT_BY_CODE
        }
    }
}
