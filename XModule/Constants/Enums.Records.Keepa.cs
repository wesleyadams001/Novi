using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Constants
{
    /// <summary>
    /// enums class that contains all the enumerations for the project
    /// </summary>
    public static partial class Enums
    {
        /// <summary>
        /// Enum using bit flags that indicates the Keepa Record Type
        /// </summary>
        [Flags]
        public enum KeepaRecordType
        {
            Default,

            /// <summary>
            /// A best sellers record
            /// </summary>
            BestSellerRecord = 0x00000001,

            /// <summary>
            /// A category record that is derived from a product response
            /// </summary>
            CategoryRecord = 0x00000002,

            /// <summary>
            /// A deal record
            /// </summary>
            DealRecord = 0x00000004,

            /// <summary>
            /// A market place record
            /// </summary>
            MarketplaceOfferRecord = 0x00000008,

            /// <summary>
            /// A notification record
            /// </summary>
            NotificationRecord = 0x00000010,

            /// <summary>
            /// A base product record
            /// </summary>
            ProductRecord = 0x00000020,

            /// <summary>
            /// A seller Record
            /// </summary>
            SellerRecord = 0x00000040,

            /// <summary>
            /// A statistics record from a responses product property
            /// </summary>
            StatisitcsRecord = 0x00000080,

            /// <summary>
            /// A Tracking creation record
            /// </summary>
            TrackingCreationRecord = 0x00000100,

            /// <summary>
            /// A Tracking record
            /// </summary>
            TrackingRecord = 0x00000200,

            /// <summary>
            /// Most Ratedseller 
            /// </summary>
            TopSellerRecord = 0x00000400,

            /// <summary>
            /// EAN record from a responses product property
            /// </summary>
            EanRecord = 0x00000800,

            /// <summary>
            /// An Ebay record from a responses product property
            /// </summary>
            EbayListingRecord = 0x00001000,

            /// <summary>
            /// A Features record from a responses product property
            /// </summary>
            FeaturesRecord = 0x00002000,

            /// <summary>
            /// A Frequently bought together record from a responses product property
            /// </summary>
            FrequentlyBoughtTogetherRecord = 0x00004000,

            /// <summary>
            /// A Languages record from a response product property
            /// </summary>
            LanguagesRecord = 0x00008000,

            /// <summary>
            /// A live offers order record from a response product property
            /// </summary>
            LiveOffersOrderRecord = 0x00010000,

            /// <summary>
            /// A offers record froma response product property
            /// </summary>
            OffersRecord = 0x00020000,

            /// <summary>
            /// A Promotion record from a response product property
            /// </summary>
            PromotionsRecord = 0x00040000,

            /// <summary>
            /// An UPC record from a response product property
            /// </summary>
            UpcRecord = 0x00080000,

            /// <summary>
            /// A variations record from a response product property
            /// </summary>
            VariationsRecord = 0x00100000,

            /// <summary>
            /// A categorytree record from a response product property
            /// </summary>
            CategoryTreeRecord = 0x00200000,

            /// <summary>
            /// A FBA Fees record from a response product property
            /// </summary>
            FbaFeesRecord = 0x00400000,

            /// <summary>
            /// A Price History record from a response product property
            /// </summary>
            PriceHistoryRecord = 0x00800000,

            /// <summary>
            /// An Item record associated with a seller record
            /// </summary>
            SellerItemRecord = 0x01000000,

            /// <summary>
            /// A category record that corresponds to a lookedup category request
            /// </summary>
            CategoryLookupRecord = 0x02000000
            //additional bit flags
            //0x04000000
            //0x08000000
            //0x10000000
            //0x20000000
            //0x40000000
            //0x80000000
        }
    }
}
