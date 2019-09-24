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
        /// Enumeration that represents the Keepa Response types
        /// </summary>
        [Flags]public enum KeepaResponseTypes
        {
            Default,
            BestSellersObject,
            CategoryObject,
            DealObject,
            MarketplaceOfferObject,
            NotificationObject,
            ProductObject,
            SellerObject,
            StatisticsObject,
            TrackingCreationObject,
            TrackingObject
        }
    }
}
