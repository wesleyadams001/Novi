using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Tools;
using static XModule.Constants.Enums;

namespace KeepaModule.DataAccess.Records
{
    /// <summary>
    /// A category object
    /// </summary>
    public class CategoryLookupRecord : Record
    {
        /// <summary>
        /// The default constructor of Category object
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="catId"></param>
        /// <param name="name"></param>
        /// <param name="children"></param>
        /// <param name="parent"></param>
        /// <param name="highestRank"></param>
        /// <param name="productCount"></param>
        public CategoryLookupRecord(byte domainId, long catId, string name, long[] children, long parent, int highestRank, int productCount)
        {
            this.domainId = domainId;
            this.catId = catId;
            this.name = name;
            this.children = children;
            this.parent = parent;
            this.highestRank = highestRank;
            this.productCount = productCount;
            this.TimeStamp = Utilities.GetUnixTime();
            this.KeepaRecordType = KeepaRecordType.CategoryLookupRecord;
            this.RecordType = RecordType.Keepa;
        }

        /// <summary>
        ///  Integer value for the Amazon locale this category belongs to.
        ///  {@link AmazonLocale}
        /// </summary>
        public byte domainId;

        /// <summary>
        ///  The category node id used by Amazon. Represents the identifier of the category. Also part of the Product object's categories and rootCategory fields. Always a positive Long value.
        /// </summary>
        public long catId;

        /// <summary>
        ///  The name of the category.
        /// </summary>
        public String name;

        /// <summary>
        ///  List of all sub categories. null or [] (empty array) if the category has no sub categories.
        /// </summary>
        public long[] children;

        /// <summary>
        ///  The parent category's Id. Always a positive Long value. If it is 0 the category is a root category and has no parent category.
        /// </summary>
        public long parent;

        /// <summary>
        ///  The highest (root category) sales rank we have observed of a product that is listed in this category. Note: Estimate, as the value is from the Keepa product database and not retrieved from Amazon.
        /// </summary>
        public int highestRank;

        /// <summary>
        ///  Number of products that are listed in this category. Note: Estimate, as the value is from the Keepa product database and not retrieved from Amazon.
        /// </summary>
        public int productCount;

    }
}
