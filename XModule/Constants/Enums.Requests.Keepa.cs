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
            [Description("Ntfs_DEFAULT")]
            Ntfs_DEFAULT,
            [Description("Ntfs_DEALS_REQUEST")]
            Ntfs_DEALS_REQUEST,
            [Description("Ntfs_PRODUCT_FINDER")]
            Ntfs_PRODUCT_FINDER,
            [Description("Ntfs_TRACKING_ADD")]
            Ntfs_TRACKING_ADD,
            [Description("Ntfs_TRACKING_BATCH_ADD")]
            Ntfs_TRACKING_BATCH_ADD,
            [Description("Ntfs_TRACKING_GET")]
            Ntfs_TRACKING_GET,
            [Description("Ntfs_TRACKING_LIST")]
            Ntfs_TRACKING_LIST,
            [Description("Ntfs_TRACKING_NOTIFICATION")]
            Ntfs_TRACKING_NOTIFICATION,
            [Description("Ntfs_TRACKING_REMOVE")]
            Ntfs_TRACKING_REMOVE,
            [Description("Ntfs_TRACKING_REMOVE_ALL")]
            Ntfs_TRACKING_REMOVE_ALL,
            [Description("Ntfs_TRACKING_WEB_HOOK")]
            Ntfs_TRACKING_WEB_HOOK,
            [Description("Ntfs_BEST_SELLERS")]
            Ntfs_BEST_SELLERS,
            [Description("Ntfs_CATEGORY_LOOKUP")]
            Ntfs_CATEGORY_LOOKUP,
            [Description("Ntfs_CATEGORY_SEARCH")]
            Ntfs_CATEGORY_SEARCH,
            [Description("Ntfs_SELLER")]
            Ntfs_SELLER,
            [Description("Ntfs_TOP_SELLER")]
            Ntfs_TOP_SELLER,
            [Description("Ntfs_PRODUCT_SEARCH")]
            Ntfs_PRODUCT_SEARCH,
            [Description("Ntfs_PRODUCT")]
            Ntfs_PRODUCT,
            [Description("Ntfs_PRODUCT_BY_CODE")]
            Ntfs_PRODUCT_BY_CODE
        }
    }
}
