using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XModule.Constants.Enums;

namespace NtfsModule.Models
{
    /// <summary>
    ///  Represents a Tracking Object
    /// "metaData": String,
    /// "thresholdValues": TrackingThresholdValue array,
    /// "notifyIf": TrackingNotifyIf array,
    /// "notificationType": Boolean array,
    /// "notificationCSV": Integer array,
    /// "individualNotificationInterval": Integer
    /// </summary>
    public class Tracking
    {

        /// <summary>
        ///The tracked product ASIN
        /// </summary>
        public String asin = null;

        /// <summary>
        ///Creation date of the tracking in {@link NtfsTime} minutes
        /// </summary>
        public int createDate;

        /// <summary>
        ///The time to live in hours until the tracking expires and is deleted. When setting the value through the _Add Tracking_ request it is in relation to the time of request,
        ///when retrieving the tracking object it is relative to the `createDate`. Possible values:<br>
        ///<blockquote>any positive integer: time to live in hours<br>
        ///0: never expires<br>
        ///any negative integer (only when setting the value):<br>
        ///<blockquote>tracking already exists: keep the original `ttl`<br>tracking is new: use the absolute value as `ttl`</blockquote>
        ///</blockquote>
        /// </summary>
        public int ttl;

        /// <summary>
        ///Trigger a notification if tracking expires or is removed by the system (e.g. product deprecated)
        /// </summary>
        public bool expireNotify;

        /// <summary>
        ///The main Amazon locale of this tracking determines the currency used for all desired prices. <br>
        ///Integer value for the Amazon locale {@link AmazonLocale}
        /// </summary>
        public byte mainDomainId;

        /// <summary>
        ///Contains all settings for price or value related tracking criteria
        /// </summary>
        public TrackingThresholdValue[] thresholdValues;

        /// <summary>
        ///Contains specific, meta tracking criteria, like out of stock.
        /// </summary>
        public TrackingNotifyIf[] notifyIf;

        /// <summary>
        ///Determines through which channels we will send notifications.<br>Must be a bool array with the length of the NotificationType enum.
        ///Uses NotificationType indexing {@link NotificationType}. True means the channel will be used.<br>
        ///Our Tracking API currently only supports notifications through push webhooks or API pull request. Other channels will follow soon.<br><br>
        ///Example: Only notify via API: [ false, false, false, false, false, true, false ]<br>
        ///  <code>
        ///    bool[] notificationType = new bool[Tracking.NotificationType.values.length];<br>
        ///    notificationType[Tracking.NotificationType.API.ordinal()] = true;
        ///  </code>
        /// </summary>
        public bool[] notificationType;

        /// <summary>
        ///A history of past notifications of this tracking. Each past notification consists of 5 entries, in the format:<br>
        ///[{@link AmazonLocale}, {@link Product.CsvType}, {@link NotificationType}, {@link TrackingNotificationCause}, {@link NtfsTime}]
        /// </summary>
        public int[] notificationCSV;

        /// <summary>
        ///A tracking specific rearm timer.<br>
        ///-1 = use default notification timer of the user account (changeable via the website settings)
        ///0 = never notify a desired price more than once
        ///larger than 0 = rearm the desired price after x minutes.
        /// </summary>
        public int individualNotificationInterval;

        /// <summary>
        ///Whether or not the tracking is active. A tracking is automatically deactivated if the corresponding API account is no longer sufficiently paid for.
        /// </summary>
        public bool isActive;

        /// <summary>
        ///The update interval, in hours. Determines how often our system will trigger a product update. A setting of 1 hour will not trigger an update exactly every 60 minutes, but as close to that as it is efficient for our system. Throughout a day it will be updated 24 times, but the updates are not perfectly distributed.
        /// </summary>
        public int updateInterval;

        /// <summary>
        ///The meta data of this tracking (max length is 500 characters). Used to assign some text to this tracking, like a user reference or a memo.
        /// </summary>
        public String metaData;

        /// <summary>
        ///Available notification channels
        /// </summary>
        public enum NotificationType
        {
            EMAIL, TWITTER, FACEBOOK_NOTIFICATION, BROWSER, FACEBOOK_MESSENGER_BOT, API, MOBILE_APP, DUMMY
            //public static final NotificationType[] values = NotificationType.values();

        }

        /// <summary>
        ///The cause that triggered a notification
        /// </summary>
        public enum TrackingNotificationCause
        {
            EXPIRED, DESIRED_PRICE, PRICE_CHANGE, PRICE_CHANGE_AFTER_DESIRED_PRICE, OUT_STOCK, IN_STOCK, DESIRED_PRICE_AGAIN
            //public static final TrackingNotificationCause[] values = TrackingNotificationCause.values();
        }


        /// <summary>
        ///Available notification meta trigger types
        /// </summary>
        public enum NotifyIfType
        {
            OUT_OF_STOCK, BACK_IN_STOCK
            //public static final NotifyIfType[] values = NotifyIfType.values();
        }

        /// <summary>
        ///Represents a desired price - a {@link Product.CsvType} of a specific {@link AmazonLocale} to be monitored
        /// </summary>
        public class TrackingThresholdValue
        {

            public TrackingThresholdValue(AmazonLocale domainId, CsvType csvType, int thresholdValue, bool isDrop, int minDeltaAbsolute, int minDeltaPercentage, bool? deltasAreBetweenNotifications)
            {
                this.thresholdValue = thresholdValue;
                this.isDrop = isDrop;
                this.domain = (byte)domainId;
                this.csvType = (int)csvType;
                this.minDeltaAbsolute = minDeltaAbsolute;
                this.minDeltaPercentage = minDeltaPercentage;
                this.deltasAreBetweenNotifications = deltasAreBetweenNotifications == null ? false : deltasAreBetweenNotifications;
            }

            /// <summary>
            ///The history of threshold values (or desired prices). Only for existing tracking!<br>
            ///Format: [{@link NtfsTime}, value]
            /// </summary>
            public int[] thresholdValueCSV;

            /// <summary>
            ///The threshold value (or desired price). Only for creating a tracking!
            /// </summary>
            public int thresholdValue;

            /// <summary>
            ///Integer value of the {@link AmazonLocale} this threshold value belongs to. Regardless of the locale, the threshold value is always in the currency of the mainDomainId.
            /// </summary>
            public byte domain;

            /// <summary>
            ///Integer value of the {@link Product.CsvType} for this threshold value
            /// </summary>
            public int csvType;

            /// <summary>
            ///Whether or not this tracking threshold value tracks value drops (true) or value increases (false)
            /// </summary>
            public bool isDrop;

            /// <summary>
            ///not yet available.
            /// </summary>
            public int minDeltaAbsolute;

            /// <summary>
            ///not yet available.
            /// </summary>
            public int minDeltaPercentage;

            /// <summary>
            ///not yet available.
            /// </summary>
            public bool? deltasAreBetweenNotifications;
        }

        public class TrackingNotifyIf
        {

            public TrackingNotifyIf(AmazonLocale domainId, CsvType csvType, NotifyIfType notifyIfType)
            {
                this.domain = (byte)domainId;
                this.csvType = (int)csvType;
                this.notifyIfType = (int)notifyIfType;
            }

            /// <summary>
            ///Integer value of the {@link AmazonLocale} for this NotifyIf
            /// </summary>
            public byte domain;

            /// <summary>
            ///The {@link Product.CsvType} for this threshold value
            /// </summary>
            public int csvType;

            /// <summary>
            ///The {@link NotifyIfType}
            /// </summary>
            public int notifyIfType;
        }
    }
}
