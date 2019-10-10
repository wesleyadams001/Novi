using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepaModule.Models
{
    /// <summary>
    /// Represents a price alert
    /// </summary>
    public class Notification
    {

        /// <summary>
        /// The notified product ASIN
        /// </summary>
        public string asin = null;

        /// <summary>
        /// Title of the product. Caution: may contain HTML markup in rare cases.
        /// </summary>
        public string title;

        /// <summary>
        /// The main image name of the product. Full Amazon image path:<br>
        /// https://images-na.ssl-images-amazon.com/images/I/_image name_
        /// </summary>
        public string image;

        /// <summary>
        /// Creation date of the notification in {@link KeepaTime} minutes
        /// </summary>
        public int createDate;

        /// <summary>
        /// The main Amazon locale of the tracking which determines the currency used for all prices of this notification.<br>
        /// Integer value for the Amazon locale {@link AmazonLocale}
        /// </summary>
        public byte domainId;

        /// <summary>
        /// The Amazon locale which triggered the notification.<br>
        /// Integer value for the Amazon locale {@link AmazonLocale}
        /// </summary>
        public byte notificationDomainId;

        /// <summary>
        /// The {@link Product.CsvType} which triggered the notification.
        /// </summary>
        public int csvType;

        /// <summary>
        /// The {@link Tracking.TrackingNotificationCause} of the notification.
        /// </summary>
        public int trackingNotificationCause;

        /// <summary>
        /// Contains the prices / values of the product of the time this notification was created.
        /// <p>Uses {@link Product.CsvType} indexing.</p>
        /// The price is an integer of the respective Amazon locale's smallest currency unit (e.g. euro cents or yen).
        /// If no offer was available in the given interval (e.g. out of stock) the price has the value -1.
        /// </summary>
        public int[] currentPrices;

        /// <summary>
        /// States through which notification channels ({@link Tracking.NotificationType}) this notification was delivered.
        /// </summary>
        public bool[] sentNotificationVia;

        /// <summary>
        /// The meta data of the tracking.
        /// </summary>
        public string metaData;
    }
}
