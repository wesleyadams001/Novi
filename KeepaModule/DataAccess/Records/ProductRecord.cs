using System;
using System.Collections.Generic;
using System.Text;
using static XModule.Constants.Enums;
using XModule.Tools;
using KeepaModule.Tools;

namespace KeepaModule.DataAccess.Records
{
    /// <summary>
    /// A product record
    /// </summary>
    public class ProductRecord : Record
    {
        /// <summary>
        /// Default constructor for the Product Record
        /// </summary>
        /// <param name="productType"></param>
        /// <param name="asin"></param>
        /// <param name="domainId"></param>
        /// <param name="title"></param>
        /// <param name="trackingSince"></param>
        /// <param name="listedSince"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="lastRatingUpdate"></param>
        /// <param name="lastPriceChange"></param>
        /// <param name="lastEbayUpdate"></param>
        /// <param name="imagesCSV"></param>
        /// <param name="rootCategory"></param>
        /// <param name="parentAsin"></param>
        /// <param name="variationCSV"></param>
        /// <param name="mpn"></param>
        /// <param name="hasReviews"></param>
        /// <param name="type"></param>
        /// <param name="manufacturer"></param>
        /// <param name="brand"></param>
        /// <param name="label"></param>
        /// <param name="department"></param>
        /// <param name="publisher"></param>
        /// <param name="productGroup"></param>
        /// <param name="partNumber"></param>
        /// <param name="author"></param>
        /// <param name="binding"></param>
        /// <param name="numberOfItems"></param>
        /// <param name="numberOfPages"></param>
        /// <param name="publicationDate"></param>
        /// <param name="releaseDate"></param>
        /// <param name="studio"></param>
        /// <param name="genre"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <param name="size"></param>
        /// <param name="edition"></param>
        /// <param name="platform"></param>
        /// <param name="format"></param>
        /// <param name="description"></param>
        /// <param name="hazardousMaterialType"></param>
        /// <param name="packageHeight"></param>
        /// <param name="packageLength"></param>
        /// <param name="packageWidth"></param>
        /// <param name="packageWeight"></param>
        /// <param name="packageQuantity"></param>
        /// <param name="availabilityAmazon"></param>
        /// <param name="isAdultProduct"></param>
        /// <param name="newPriceIsMAP"></param>
        /// <param name="isEligibleForTradeIn"></param>
        /// <param name="isEligibleForSuperSaverShipping"></param>
        /// <param name="fbaFees"></param>
        /// <param name="isRedirectASIN"></param>
        /// <param name="isSNS"></param>
        /// <param name="offersSuccessful"></param>
        public ProductRecord(int? productType, string asin, int? domainId, string title, int? trackingSince, int? listedSince, int? lastUpdate, int? lastRatingUpdate, int? lastPriceChange, int? lastEbayUpdate, string imagesCSV, long? rootCategory, string parentAsin, string variationCSV, string mpn, bool? hasReviews, string type, string manufacturer, string brand, string label, string department, string publisher, string productGroup, string partNumber, string author, string binding, int? numberOfItems, int? numberOfPages, int? publicationDate, int? releaseDate, string studio, string genre, string model, string color, string size, string edition, string platform, string format, string description, int? hazardousMaterialType, int? packageHeight, int? packageLength, int? packageWidth, int? packageWeight, int? packageQuantity, int? availabilityAmazon, bool? isAdultProduct, bool? newPriceIsMAP, bool? isEligibleForTradeIn, bool? isEligibleForSuperSaverShipping, bool? isRedirectASIN, bool? isSNS, bool? offersSuccessful)
        {
            IncrementalNumberGenerator generator = new IncrementalNumberGenerator();
            this.ProductId = generator.Next();
            this.productType = productType;
            this.asin = asin;
            this.domainId = domainId;
            this.title = title;
            this.trackingSince = trackingSince;
            this.listedSince = listedSince;
            this.lastUpdate = lastUpdate;
            this.lastRatingUpdate = lastRatingUpdate;
            this.lastPriceChange = lastPriceChange;
            this.lastEbayUpdate = lastEbayUpdate;
            this.imagesCSV = imagesCSV;
            this.rootCategory = rootCategory;
            this.parentAsin = parentAsin;
            this.variationCSV = variationCSV;
            this.mpn = mpn;
            this.hasReviews = hasReviews;
            this.type = type;
            this.manufacturer = manufacturer;
            this.brand = brand;
            this.label = label;
            this.department = department;
            this.publisher = publisher;
            this.productGroup = productGroup;
            this.partNumber = partNumber;
            this.author = author;
            this.binding = binding;
            this.numberOfItems = numberOfItems;
            this.numberOfPages = numberOfPages;
            this.publicationDate = publicationDate;
            this.releaseDate = releaseDate;
            this.studio = studio;
            this.genre = genre;
            this.model = model;
            this.color = color;
            this.size = size;
            this.edition = edition;
            this.platform = platform;
            this.format = format;
            this.description = description;
            this.hazardousMaterialType = hazardousMaterialType;
            this.packageHeight = packageHeight;
            this.packageLength = packageLength;
            this.packageWidth = packageWidth;
            this.packageWeight = packageWeight;
            this.packageQuantity = packageQuantity;
            this.availabilityAmazon = availabilityAmazon;
            this.isAdultProduct = isAdultProduct;
            this.newPriceIsMAP = newPriceIsMAP;
            this.isEligibleForTradeIn = isEligibleForTradeIn;
            this.isEligibleForSuperSaverShipping = isEligibleForSuperSaverShipping;
            
            this.isRedirectASIN = isRedirectASIN;
            this.isSNS = isSNS;
            this.offersSuccessful = offersSuccessful;
            this.RecordType = RecordType.Keepa;
            this.KeepaRecordType = KeepaRecordType.ProductRecord;
            this.TimeStamp = XModule.Tools.Utilities.GetUnixTime();
        }

        //Properties that constitute a product record.
        #region Properties
        public ulong ProductId { get; set; }
        public int? productType { get; set; }
        public string asin { get; set; }
        public int? domainId { get; set; }
        public string title { get; set; }
        public int? trackingSince { get; set; }
        public int? listedSince { get; set; }
        public int? lastUpdate { get; set; }
        public int? lastRatingUpdate { get; set; }
        public int? lastPriceChange { get; set; }
        public int? lastEbayUpdate { get; set; }
        public string imagesCSV { get; set; }
        public long? rootCategory { get; set; }
        public string parentAsin { get; set; }
        public string variationCSV { get; set; }
        public string mpn { get; set; }
        public bool? hasReviews { get; set; }
        public string type { get; set; }
        public string manufacturer { get; set; }
        public string brand { get; set; }
        public string label { get; set; }
        public string department { get; set; }
        public string publisher { get; set; }
        public string productGroup { get; set; }
        public string partNumber { get; set; }
        public string author { get; set; }
        public string binding { get; set; }
        public int? numberOfItems { get; set; }
        public int? numberOfPages { get; set; }
        public int? publicationDate { get; set; }
        public int? releaseDate { get; set; }
        public string studio { get; set; }
        public string genre { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string edition { get; set; }
        public string platform { get; set; }
        public string format { get; set; }
        public string description { get; set; }
        public int? hazardousMaterialType { get; set; }
        public int? packageHeight { get; set; }
        public int? packageLength { get; set; }
        public int? packageWidth { get; set; }
        public int? packageWeight { get; set; }
        public int? packageQuantity { get; set; }
        public int? availabilityAmazon { get; set; }
        public bool? isAdultProduct { get; set; }
        public bool? newPriceIsMAP { get; set; }
        public bool? isEligibleForTradeIn { get; set; }
        public bool? isEligibleForSuperSaverShipping { get; set; }
        public object fbaFees { get; set; }
        public bool? isRedirectASIN { get; set; }
        public bool? isSNS { get; set; }
        public bool? offersSuccessful { get; set; }
        #endregion

    }
}
