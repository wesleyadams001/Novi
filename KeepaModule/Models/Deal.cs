using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtfsModule.Models
{
    /// <summary>
    /// About:
    /// A Deal object represents a product that has recently changed (usually in price or sales rank). It contains a summary of the product and information about the changes.
    /// <p>
    /// Returned by:
    /// The Deal object is returned by the Browsing Deals request.
    /// </summary>
    public class Deal
    {

        /// <summary>
        /// The ASIN of the product
        /// </summary>
        public string asin = null;

        /// <summary>
        /// Title of the product. Caution: may contain HTML markup in rare cases.
        /// </summary>
        public string title = null;

        /// <summary>
        /// Contains the absolute difference between the current value and the average value of the respective date range interval.
        /// The value 0 means it did not change or could not be calculated. First dimension uses the Date Range indexing, second the Price Type indexing.
        /// <p>First dimension uses {@link Product.CsvType}, second domension {@link DealInterval}</p>
        /// </summary>
        public int[][] delta = null;

        /// <summary>
        /// Same as {@link #delta}, but given in percent instead of absolute values.
        /// <p>First dimension uses {@link Product.CsvType}, second domension {@link DealInterval}</p>
        /// </summary>
        public short[][] deltaPercent = null;

        /// <summary>
        /// Contains the absolute difference of the current and the previous price / rank. The value 0 means it did not change or could not be calculated.
        /// <p>Uses {@link Product.CsvType} indexing</p>
        /// </summary>
        public int[] deltaLast = null;

        /// <summary>
        /// Contains the weighted averages in the respective date range and price type.<br>
        /// <b>Note:</b> The day interval (index 0) is actually the average of the last 48 hours, not 24 hours. This is due to the way our deals work.
        /// <p>First dimension uses {@link Product.CsvType}, second domension {@link DealInterval}</p>
        /// </summary>
        public int[][] avg = null;

        /// <summary>
        /// Contains the prices / ranks of the product of the time we last updated it. Uses the Price Type indexing.
        /// The price is an integer of the respective Amazon locale's smallest currency unit (e.g. euro cents or yen).
        /// If no offer was available in the given interval (e.g. out of stock) the price has the value -1.
        /// Shipping and Handling costs are not included. Amazon is considered to be part of the marketplace, so if
        /// Amazon has the overall lowest new price, the marketplace new price in the corresponding time interval will
        /// be identical to the Amazon price (except if there is only one marketplace offer).
        /// <p>Uses {@link Product.CsvType} indexing</p>
        /// </summary>
        public int[] current = null;

        /// <summary>
        /// Category node id {@link Category#catId} of the product's root category. 0 or 9223372036854775807 if no root category known.
        /// </summary>
        public long? rootCat = 0L;

        /// <summary>
        /// States the time this deal was found, in Ntfs Time minutes.<br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        /// </summary>
        public int? creationDate = 0;

        /// <summary>
        /// The name of the main product image of the product. Make sure you own the rights to use the image.<br>
        /// Each entry represents the integer of a US-ASCII (ISO646-US) coded character. Easiest way to convert it to a string in Javascript would be var imageName = string.fromCharCode.apply("", productObject.image);.<br>
        /// Example: [54,49,107,51,76,97,121,55,74,85,76,46,106,112,103], which equals "61k3Lay7JUL.jpg".<br>
        /// Full Amazon image path: https://images-na.ssl-images-amazon.com/images/I/_image name_
        /// </summary>
        public byte[] image = null;

        /// <summary>
        /// Array of Amazon category node ids {@link Category#catId} this product is listed in. Can be empty.<br>
        /// Example: [569604]
        /// </summary>
        public long[] categories = null;

        /// <summary>
        /// States the last time we have updated the information for this deal, in Ntfs Time minutes.<br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        /// </summary>
        public int? lastUpdate = 0;

        /// <summary>
        /// States the time this lightning deal is scheduled to end, in Ntfs Time minutes. Only applicable to lightning deals. 0 otherwise. <br>
        /// Use {@link NtfsTime#NtfsMinuteToUnixInMillis(int)} (long)} to get an uncompressed timestamp (Unix epoch time).
        /// </summary>
        public int? lightningEnd = 0;

        public Deal(string asin, string title, int[][] delta, short[][] deltaPercent, int[] deltaLast, int[][] avg, int[] current, long? rootCat, int? creationDate, byte[] image, long[] categories, int? lastUpdate, int? lightningEnd)
        {
            this.asin = asin ?? throw new ArgumentNullException(nameof(asin));
            this.title = title ?? throw new ArgumentNullException(nameof(title));
            this.delta = delta ?? throw new ArgumentNullException(nameof(delta));
            this.deltaPercent = deltaPercent ?? throw new ArgumentNullException(nameof(deltaPercent));
            this.deltaLast = deltaLast ?? throw new ArgumentNullException(nameof(deltaLast));
            this.avg = avg ?? throw new ArgumentNullException(nameof(avg));
            this.current = current ?? throw new ArgumentNullException(nameof(current));
            this.rootCat = rootCat ?? throw new ArgumentNullException(nameof(rootCat));
            this.creationDate = creationDate ?? throw new ArgumentNullException(nameof(creationDate));
            this.image = image ?? throw new ArgumentNullException(nameof(image));
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
            this.lastUpdate = lastUpdate ?? throw new ArgumentNullException(nameof(lastUpdate));
            this.lightningEnd = lightningEnd ?? throw new ArgumentNullException(nameof(lightningEnd));
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
